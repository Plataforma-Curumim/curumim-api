using curumim_api.Adapters.Outbound.SQL.Models;

namespace curumim_api.Application.Core.DomainModels.Base
{
    public class BaseError
    {
        public string codigo { get; set; }
        public string? mensagem { get; set; }
        public ICollection<Error>? erros { get; set; }

        public BaseError(string codigo, string mensagem = "")
        {
            this.codigo = codigo;
            this.mensagem = mensagem;
        }
        public BaseError(SqlBaseError sqlError)
        {
            codigo = "400";
            mensagem = "Erro no banco de dados";
            erros = [new Error("Database", [sqlError.msgError])];
        }
    }
}
