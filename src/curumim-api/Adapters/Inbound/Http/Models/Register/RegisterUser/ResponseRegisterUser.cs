namespace curumim_api.Adapters.Inbound.Http.Models.Register.RegisterUser
{
    public record ResponseRegisterUser
    {
        public string? createAt { get; set; }
        public string? idUser { get; set; }
        public string? state { get; set; }
    }
}
