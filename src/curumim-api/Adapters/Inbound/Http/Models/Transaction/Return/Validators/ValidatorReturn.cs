using System.Validation;

namespace curumim_api.Adapters.Inbound.Http.Models.Transaction.Return.Validators;

public class ValidatorReturn : FlatValidator<RequestReturn>
{
    public ValidatorReturn()
    {
        ErrorIf(m => m.bookId is null, m => "Não pode ser nulo ou vazio", m => m.bookId);
        ErrorIf(m => m.userId is null, m => "Não pode ser nulo ou vazio", m => m.userId);
    }
}