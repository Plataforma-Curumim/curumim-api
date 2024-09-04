namespace curumim_api.Adapters.Inbound.Http.Models.Transaction.Lend;

public record RequestLend
{
    public string? userId { get; set; }
    public string? bookId { get; set; }
    public int? daysOfLend { get; set; }
}