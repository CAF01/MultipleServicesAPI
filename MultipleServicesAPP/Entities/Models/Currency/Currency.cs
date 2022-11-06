namespace MultipleServicesAPP.Entities.Models.Currency
{
    public class Currency
    {
        public MsgResponse motd { get; set; }
        public bool success { get; set; }
        public Query query { get; set; }
        public Info info { get; set; }
        public bool historical { get; set; }
        public string date { get; set; }
        public float result { get; set; }
    }

    public class MsgResponse
    {
        public string msg { get; set; }
        public string url { get; set; }
    }

    public class Query
    {
        public string from { get; set; }
        public string to { get; set; }
        public float amount { get; set; }
    }

    public class Info
    {
        public float rate { get; set; }
    }

}
