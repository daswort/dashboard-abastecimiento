using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace DashboardAbast.Client.Pages
{
    public partial class Index
    {
        [Inject] IProveedorService ProveedorService { get; set; }        
        [Inject] ICentroCostoService CentroCostoService { get; set; }        
        [Inject] IGerenciaService GerenciaService { get; set; }        
        [Inject] IJefaturaService JefaturaService { get; set; }        
        [Inject] IFamiliaService FamiliaService { get; set; }        
        [Inject] IEjecutivoService EjecutivoService { get; set; }        
        [Inject] IDespachosDiaService DespachosDiaService { get; set; }        
        [Inject] IDespachosAtrasadosService DespachosAtrasadosService { get; set; }     
        [Inject] IResumenEntidadService ResumenEntidadService { get; set; }

        [Parameter] public List<string>? Divisiones { get; set; }
        [Parameter] public List<UIResumenEntidad>? ResumenCasinos { get; set; }
        [Parameter] public List<UIResumenEntidad>? ResumenProveedores { get; set; }
        [Parameter] public List<UIResumenEntidad>? ResumenEjecutivos { get; set; }
        [Parameter] public List<UIResumenEntidad>? ResumenDiarioEjecutivos { get; set; }
        [Parameter] public List<UIResumenEntidad>? ResumenAtrasadosEjecutivos { get; set; }
        [Parameter] public DateTime FechaIni { get; set; } = DateTime.Today;
        [Parameter] public DateTime FechaFin { get; set; } = DateTime.Today;
        [Parameter] public IEnumerable<string> CentroCostos { get; set; } = new string[] { "" };
        [Parameter] public IEnumerable<string> Proveedores { get; set; } = new string[] { "" };
        [Parameter] public IEnumerable<string> Ejecutivos { get; set; } = new string[] { "" };
        [Parameter] public IEnumerable<string> Familias { get; set; } = new string[] { "" };

        private int pageIndexDelDia = 1;
        private int pageIndexAtrasados = 1;
        private string columnNameDelDia;
        private string columnValueDelDia;
        private string columnNameAtrasados;
        private string columnValueAtrasados;

        private readonly FilterEntidades filterEntidades = new();
        private readonly FilterDespachosDeHoy filterDespachosDeHoy = new();
        private readonly FilterDespachosAtrasados filterDespachosAtrasados = new();
        private readonly FilterHistorico filterHistorico = new();

        private RadzenDataGrid<StOrdenCompra> gridDelDia;
        private RadzenDataGrid<StOrdenCompra> gridAtrasadas;

        [Parameter] public bool isLoadingDespachosDelDia { get; set; } = false;
        bool isLoadingResumenDiarioEjecutivo = true;
        bool isLoadingResumenAtrasadosEjecutivo = true;
        bool isLoadingDespachosAtrasados = true;
        bool isLoadingResumenHistorico = true;

        private static System.Timers.Timer aTimer;

        bool isLoading;
        bool autoRefreshDelDia;
        bool autoRefreshAtrasadas;
        int countDeldia;
        int countAtrasadas;

        protected override async Task OnInitializedAsync()
        {
            //isLoadingDespachosDelDia = true;

            DateTime oPrimerDiaDelMes = new(FechaIni.Year, FechaIni.Month, 1);
            FechaFin = FechaFin.AddDays(1).AddSeconds(-1);
            

            filterEntidades.CentroCostos = CentroCostos;
            filterEntidades.Proveedores = Proveedores;
            filterEntidades.Ejecutivos = Ejecutivos;
            filterEntidades.Familias = Familias;

            filterDespachosDeHoy.FechaIni = FechaIni;
            filterDespachosDeHoy.FechaFin = FechaFin;

            filterDespachosAtrasados.FechaIni = oPrimerDiaDelMes;
            filterDespachosAtrasados.FechaFin = FechaFin.AddDays(-1);

            filterHistorico.FechaIni = FechaIni.AddMonths(-1);
            filterHistorico.FechaFin = FechaFin;

            List<Task> tasks = new()
            {
                ProveedorService.GetProveedores(FechaIni, FechaFin),
                FamiliaService.GetFamilias(),
                EjecutivoService.GetEjecutivos(),
                CentroCostoService.GetCentrosCosto()
            };

            await Task.WhenAll(tasks);

            Divisiones = new List<string>() { "TRADICIONAL", "TRANSPORTADO" };
            //await ProveedorService.GetProveedores(oFechaIni, oFechaFin);
            //await FamiliaService.GetFamilias();
            //await EjecutivoService.GetEjecutivos();
            //await CentroCostoService.GetCentrosCosto();

            StateHasChanged();
        }

        protected override async Task OnParametersSetAsync()
        {
            List<Task> tasks = new List<Task> {
                LoadDespachosDelDia(),
                LoadDespachosAtrasados(),
                LoadResumenProveedor(),
                LoadResumenCasino(),
                LoadResumenEjecutivo(),
                LoadResumenDiarioEjecutivo(),
                LoadResumenAtrasadosEjecutivo()
            };

            Console.WriteLine($"Dashboard Abastecimiento - 1 isLoadingDespachosDelDia: {isLoadingDespachosDelDia}");

            await Task.WhenAll(tasks);
            //isLoadingDespachosDelDia = false;

            Console.WriteLine($"Dashboard Abastecimiento - 2 isLoadingDespachosDelDia: {isLoadingDespachosDelDia}");

            isLoadingResumenHistorico = false;
            StateHasChanged();
        }

        void OnFilterAtrasadas(DataGridColumnFilterEventArgs<StOrdenCompra> args)
        {
            columnNameAtrasados = args.Column.Title;
            columnValueAtrasados = args.FilterValue.ToString();
            pageIndexAtrasados = 1;
        }

        void OnPagingAtrasadas(PagerEventArgs args)
        {
            pageIndexAtrasados = args.PageIndex + 1;
        }

        // ###################################### INICIO Despachos Del Dia 

        private async Task LoadDespachosDelDia()
        {
            //isLoadingDespachosDelDia = true;
            await DespachosDiaService.GetDespachosDiasGrid(
                filterDespachosDeHoy.FechaIni,
                filterDespachosDeHoy.FechaFin,
                filterEntidades.CentroCostos,
                filterEntidades.Proveedores,
                filterEntidades.Familias,
                filterEntidades.Ejecutivos,
                pageIndexDelDia,
                columnNameDelDia,
                columnValueDelDia
            );
            countDeldia = DespachosDiaService.DespachosDias.TotalOcPorRecepcionar;
            //isLoadingDespachosDelDia = false;
            StateHasChanged();
            gridDelDia.CurrentPage = pageIndexDelDia - 1;
        }

        private async void OnSubmitGridDespachosDia()
        {
            DespachosDiaService.DespachosDias.UIOrdenCompra.Clear();
            List<Task> tasks = new List<Task> { LoadDespachosDelDia(), LoadResumenDiarioEjecutivo() };
            await Task.WhenAll(tasks);
            //isLoadingDespachosDelDia = false;
            StateHasChanged();
        }

        void OnClickBtnDespachosDelDia()
        {
            //isLoadingDespachosDelDia = true;
        }

        void OnChangeAutoRefreshDelDia(bool value)
        {
            //Console.WriteLine($"Dashboard Abastecimiento - OnChangeAutoRefreshDelDia: {value}");

            if (value)
            {
                aTimer = new System.Timers.Timer(60000);
                aTimer.Elapsed += async (sender, e) => await LoadDespachosDelDia();
                InvokeAsync(StateHasChanged);
                aTimer.Start();
                aTimer.Enabled = true;
            }
            else
            {
                aTimer.Enabled = false;
            }
        }

        void OnFilterDelDia(DataGridColumnFilterEventArgs<StOrdenCompra> args)
        {
            columnNameDelDia = args.Column.Title;
            columnValueDelDia = args.FilterValue.ToString();
            pageIndexDelDia = 1;
        }

        void OnPagingDelDia(PagerEventArgs args)
        {
            pageIndexDelDia = args.PageIndex + 1;
        }

        // ###################################### FIN Despachos Del Dia 

        private async Task LoadResumenAtrasadosEjecutivo()
        {
            isLoadingResumenAtrasadosEjecutivo = true;
            await ResumenEntidadService.GetResumenEntidad(
                "resumen-ejecutivo",
                filterDespachosAtrasados.FechaIni,
                filterDespachosAtrasados.FechaFin,
                filterEntidades.CentroCostos,
                filterEntidades.Proveedores,
                filterEntidades.Familias,
                filterEntidades.Ejecutivos
            );
            ResumenAtrasadosEjecutivos = ResumenEntidadService.ResumenEntidades;
            isLoadingResumenAtrasadosEjecutivo = false;
        }

        private async Task LoadResumenDiarioEjecutivo()
        {
            isLoadingResumenDiarioEjecutivo = true;
            await ResumenEntidadService.GetResumenEntidad(
                "resumen-ejecutivo",
                filterDespachosDeHoy.FechaIni,
                filterDespachosDeHoy.FechaFin,
                filterEntidades.CentroCostos,
                filterEntidades.Proveedores,
                filterEntidades.Familias,
                filterEntidades.Ejecutivos
            );
            ResumenDiarioEjecutivos = ResumenEntidadService.ResumenEntidades;
            isLoadingResumenDiarioEjecutivo = false;
        }

        private async Task LoadDespachosAtrasados()
        {
            //Console.WriteLine("Dashboard Abastecimiento - LoadDespachosAtrasados");

            isLoadingDespachosAtrasados = true;
            await DespachosAtrasadosService.GetDespachosAtrasadosGrid(
                filterDespachosAtrasados.FechaIni,
                filterDespachosAtrasados.FechaFin,
                filterEntidades.CentroCostos,
                filterEntidades.Proveedores,
                filterEntidades.Familias,
                filterEntidades.Ejecutivos
            );
            countAtrasadas = DespachosAtrasadosService.DespachosAtrasados.TotalOcPorRecepcionar;
            isLoadingDespachosAtrasados = false;
            StateHasChanged();
            gridAtrasadas.CurrentPage = pageIndexAtrasados - 1;
        }

        private async Task LoadResumenProveedor()
        {
            await ResumenEntidadService.GetResumenEntidad("resumenproveedor", filterHistorico.FechaIni, filterHistorico.FechaFin);
            ResumenProveedores = ResumenEntidadService.ResumenEntidades;
        }

        private async Task LoadResumenCasino()
        {
            await ResumenEntidadService.GetResumenEntidad("resumencasino", filterHistorico.FechaIni, filterHistorico.FechaFin);
            ResumenCasinos = ResumenEntidadService.ResumenEntidades;
        }

        private async Task LoadResumenEjecutivo()
        {
            await ResumenEntidadService.GetResumenEntidad("resumen-ejecutivo", filterHistorico.FechaIni, filterHistorico.FechaFin);
            ResumenEjecutivos = ResumenEntidadService.ResumenEntidades;
        }

        private async void OnSubmitGridDespachosAtrasados()
        {
            DespachosAtrasadosService.DespachosAtrasados.UIOrdenCompra.Clear();

            List<Task> tasks = new List<Task> { LoadDespachosAtrasados(), LoadResumenAtrasadosEjecutivo() };
            await Task.WhenAll(tasks);
            isLoadingDespachosAtrasados = false;
            StateHasChanged();
        }

        private async void OnSubmitGridHistorico()
        {
            ResumenCasinos.Clear();
            ResumenProveedores.Clear();
            ResumenEjecutivos.Clear();

            List<Task> tasks = new List<Task> {
            LoadResumenProveedor(),
            LoadResumenCasino(),
            LoadResumenEjecutivo(),
        };

            await Task.WhenAll(tasks);
            isLoadingResumenHistorico = false;
            StateHasChanged();
        }

        void OnClickBtnDespachosAtrasados()
        {
            isLoadingDespachosAtrasados = true;
        }

        void OnClickBtnFiltroHistorico()
        {
            isLoadingResumenHistorico = true;
        }

        private async void OnChangeDivision(object value)
        {
            GerenciaService.Gerencias.Clear();
            JefaturaService.Jefaturas.Clear();
            CentroCostoService.CentrosCosto.Clear();
            await GerenciaService.GetGerencias(value.ToString());
            StateHasChanged();
        }

        private async Task OnChangeGerencia(object value)
        {
            JefaturaService.Jefaturas.Clear();
            CentroCostoService.CentrosCosto.Clear();
            await JefaturaService.GetJefaturas(value.ToString());
            StateHasChanged();
        }

        private async void OnChangeJefatura(object value)
        {
            CentroCostoService.CentrosCosto.Clear();
            await CentroCostoService.GetCentrosCostoPorJefatura(value.ToString());
            StateHasChanged();
        }

        void OnChangeAutoRefreshAtrasadas(bool value)
        {
            //Console.WriteLine($"Dashboard Abastecimiento - OnChangeAutoRefreshAtrasadas: {value}");

            if (value)
            {
                aTimer = new System.Timers.Timer(60000);
                aTimer.Elapsed += async (sender, e) => await LoadDespachosAtrasados();
                InvokeAsync(StateHasChanged);
                aTimer.Start();
                aTimer.Enabled = true;
            }
            else
            {
                aTimer.Enabled = false;
            }
        }

    }

    class FilterHistorico
    {
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
    }

    class FilterEntidades
    {
        public IEnumerable<object>? CentroCostos { get; set; }
        public IEnumerable<object>? Proveedores { get; set; }
        public IEnumerable<object>? Ejecutivos { get; set; }
        public IEnumerable<object>? Familias { get; set; }
    }

    class FilterDespachosDeHoy : FilterEntidades
    {
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
    }

    class FilterDespachosAtrasados : FilterEntidades
    {
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
    }

    class FilterJerarquia
    {
        public string? Division { get; set; }
        public string? Gerencia { get; set; }
        public string? Jefatura { get; set; }
    }
}
