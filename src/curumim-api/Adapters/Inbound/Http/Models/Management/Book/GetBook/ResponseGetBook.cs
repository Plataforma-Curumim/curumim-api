namespace curumim_api.Adapters.Inbound.Http.Models.Management.Book.GetBook
{
    public record ResponseGetBook
    {
        public string? state { get; set; }
        public string? idBook { get; set; }
        public string? isbn { get; set; }
        public string? title { get; set; }
        public string? subtitle { get; set; }
        public string? author { get; set; }
        public string? sinopse { get; set; }
        public string? gender { get; set; }
        public string? language { get; set; }
        public string? urlImage { get; set; }
        public List<string>? publishers { get; set; }
        public string? publishDate { get; set; }
        public string? physicalDimensions { get; set; }
        public List<string>? publishPlaces { get; set; }
        public int? numberOfPages { get; set; }
    }
}
