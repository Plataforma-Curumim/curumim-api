namespace curumim_api.Adapters.Inbound.Http.Models.Register.RegisterBook
{
    public record ResponseRegisterBook
    {
        public string? createAt { get; set; }
        public string? idBook { get; set; }
        public string? state { get; set; }
    }
}
