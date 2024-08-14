namespace curumim_api.Adapters.Inbound.Http.Models.Management.User.EditUser
{
    public record ResponseEditUser
    {
        public string? modifiedAt { get; set; }
        public string? state { get; set; }
    }
}
