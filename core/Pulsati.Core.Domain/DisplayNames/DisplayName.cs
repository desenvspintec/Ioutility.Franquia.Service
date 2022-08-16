using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsati.Core.Domain.DisplayNames
{
    public class DisplayName
    {
        public DisplayName(string nomePropriedade, string valorDisplay)
        {
            NomePropriedade = nomePropriedade;
            ValorDisplay = valorDisplay;
        }

        public string NomePropriedade { get; private set; }
        public string ValorDisplay { get; private set; }
    }
}
