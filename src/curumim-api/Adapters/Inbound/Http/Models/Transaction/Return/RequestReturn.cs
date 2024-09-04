namespace curumim_api.Adapters.Inbound.Http.Models.Transaction.Return;

public record RequestReturn
{
    public string? userId { get; set; }
    public string? bookId { get; set; }
}