namespace curumim_api.Adapters.Inbound.Http.Dto.RegisterBook
{
    public record ResponseRegisterBook
    {
        public string? createAt { get; set; }
        public string? idBook { get; set; }
        public int? state { get; set; }
    }
}
