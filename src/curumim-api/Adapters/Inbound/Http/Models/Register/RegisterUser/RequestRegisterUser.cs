using curumim_api.Application.Core.DomainModels.Entities;
using curumim_api.Application.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace curumim_api.Adapters.Inbound.Http.Models.Register.RegisterUser
{
    public record RequestRegisterUser
    {
        public Root? root { get; set; }
        public string? name { get; set; }
        public string? cpfCnpj { get; set; }
        public string? email { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string? numberPhone { get; set; }
        public string? address { get; set; }
        public string? idRfid { get; set; }
        public EnumTypeUser typeUser { get; set; }
    }
}
