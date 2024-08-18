using curumim_api.Application.Core.DomainModels.Entities;
using curumim_api.Application.Core.Enums;

namespace curumim_api.Adapters.Inbound.Http.Models.Management.Book.EditBook
{
    public record RequestEditBook
    {
        public string? idBook { get; set; }
        public EnumTypeEdit typeEdit { get; set; }
        public EnumStateBook state { get; set; }
        public string? rfidId { get; set; }
        public string? isbn { get; set; }
        public string? title { get; set; }
        public string? subtitle { get; set; }
        public string? author { get; set; }
        public string? sinopse { get; set; }
        public string? gender { get; set; }
        public string? urlImage { get; set; }
        public int? numberOfPages { get; set; }
        public Root? root { get; set; }
    }
}
