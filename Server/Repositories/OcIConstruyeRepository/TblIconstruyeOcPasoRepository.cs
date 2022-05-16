using System.Linq;
using System.Collections.Generic;

namespace DashboardAbast.Server.Repositories.OcIConstruyeRepository
{
    public class TblIconstruyeOcPasoRepository : Repository<TblIconstruyeOcPaso>, ITblIconstruyeOcPasoRepository
    {
        public TblIconstruyeOcPasoRepository(PptoCeContext context) 
            : base(context)
        {
        }

        public IQueryable<OcNoRecepcionada> GetOrdenesCompraVigentesByFechaDespacho(OcNoRecepcionadasParametros parametros)
        {
            var query = (from t1 in PptoCeContext.Set<TblIconstruyeOcPaso>()
                     where t1.EstadoLinea != "OC Línea Cancelada"
                     && t1.EstadoLinea != "OC Línea Rechazada"
                     && t1.Fechaentrega >= parametros.FechaIni
                     && t1.Fechaentrega <= parametros.FechaFin
                     //orderby t1.NumOc, t1.Fechaentrega descending
                     select new OcNoRecepcionada()
                     {
                         NumOc = t1.NumOc,
                         CodigoProducto = t1.CodigoProducto,
                         CentroCosto = t1.CentroCosto,
                         IdProveedor = t1.RutProveedor,
                     });

            if (parametros.CentrosCosto.Any())
                query = query.Where(x => parametros.CentrosCosto.Contains(x.CentroCosto));

            if (parametros.Proveedores.Any())
                query = query.Where(x => parametros.Proveedores.Contains(x.IdProveedor));

            return query;
        }

        public PptoCeContext PptoCeContext
        {
            get { return _dbContext as PptoCeContext; }
        }
    }
}
