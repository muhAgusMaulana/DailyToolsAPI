namespace DailyToolsAPI.DataLayer
{
    public class APIDataLayer
    {
        public string Apiname { get; set; } = string.Empty;
        public string Apiparam { get; set; } = string.Empty;
        public string Apiresponse { get; set; } = string.Empty;
        public bool IsError { get; set; } = false;
        public string Exception { get; set; } = string.Empty;
    }
}
