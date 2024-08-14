namespace curumim_api.Adapters.Outbound.SQL.Models
{
    public record SqlBaseError
    {
        public string? typeError { get; set; }
        public string? codError { get; set; }
        public string? msgError { get; set; }
        public string? rootError { get; set; }
    }
}
