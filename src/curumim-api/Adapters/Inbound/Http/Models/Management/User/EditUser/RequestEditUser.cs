using curumim_api.Application.Core.DomainModels.Entities;
using curumim_api.Application.Core.Enums;

namespace curumim_api.Adapters.Inbound.Http.Models.Management.User.EditUser
{
    public record RequestEditUser
    {
        public string? userId { get; set; }
        public EnumTypeEdit typeEdit { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? numberPhone { get; set; }
        public string? address { get; set; }
        public string? idRfid { get; set; }
        public Root? root { get; set; }
    }
}
