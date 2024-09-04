namespace curumim_api.Adapters.Inbound.Http.Models.Transaction.Lend;

public record ResponseLend
{
    public string? createAt { get; set; }
    public string? idTransaction { get; set; }
    public string? dateReturn { get; set; }
    public string? state { get; set; }
}