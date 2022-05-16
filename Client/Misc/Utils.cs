namespace DashboardAbast.Client.Misc
{
    public static class Util
    {
        public static string SetFechaToApi(DateTime fecha)
        {
            string oFecha = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            return oFecha;
        }

        public static string SetListObjectsForUrlApi(IEnumerable<object> lista)
        {
            string oString = (lista == null) ? string.Empty : String.Join(",", lista);
            return oString;
        }
    }
}