using curumim_api.Application.Core.Enums;

namespace curumim_api.Adapters.Inbound.Http.Models.Management.User.GetUser
{
    public record ResponseGetUser
    {
        public string? name { get; set; }
        public string? cpfCnpj { get; set; }
        public string? email { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? dateOfBirth { get; set; }
        public string? numberPhone { get; set; }
        public string? address { get; set; }
        public string? idRfid { get; set; }
        public string? typeUser { get; set; }
    }
}
