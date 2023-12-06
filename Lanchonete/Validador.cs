using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lanchonete
{
    internal class Validador
    {
        public bool ValidarTelefone(string telefone)
        {
            Regex regex = new Regex(@"^\(\d{2}\)\s\d{4,5}-\d{4}$");
            return regex.IsMatch(telefone);
        }

    }
}
