namespace curumim_api.Adapters.Inbound.Http.Models.Transaction.Return;

public record ResponseReturn
{
    public string? dateReturn { get; set; }
    public string? state { get; set; }
}