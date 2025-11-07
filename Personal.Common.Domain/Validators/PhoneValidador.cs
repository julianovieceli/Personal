using System.Text.RegularExpressions;

namespace Personal.Common.Domain.Validators
{
    public class PhoneValidador
    {
        public static bool IsValid(string telefone)
        {
            // Exemplo de uso da regex para formato brasileiro flexível
            string padrao = @"^\(?\d{2}\)?\s?(9?\d{4,5})-?(\d{4})$";
            return Regex.IsMatch(telefone, padrao);
        }
    }
}
