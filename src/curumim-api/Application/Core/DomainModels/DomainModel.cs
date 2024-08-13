namespace curumim_api.Application.Core.DomainModels
{
    public record DomainModel
    {
        public string? idempotenceKey { get; set; }
        public string? msgIN { get; set; }
        public string? msgOUT { get; set; }
        public short? state { get; set; }
        public string? msgErro { get; set; }

    }
}
