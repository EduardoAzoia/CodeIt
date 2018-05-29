using CodeITAirLines.Tripulantes;
using CodeITAirLines.Tripulantes.TribulacaoCabine;
using CodeITAirLines.Tripulantes.TripulacaoTecninca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Veiculo
{
    public class SmartForTwo
    {
        public string Localizacao { get; set; }

        #region SMART_FOR_TWO

        public string SmartForTwoIndo { get { return SMART_FOR_TWO_INDO; } }

        private const string SMART_FOR_TWO_VOLTANDO = @"
                                                ___
                                               /_| |
                                              [o_|o]=~";

        public string SmartForTwoVoltando { get { return SMART_FOR_TWO_VOLTANDO; } }

        private const string SMART_FOR_TWO_INDO = @"
   ___
  | |_\
~=[o|_o]";

        #endregion SMART_FOR_TWO

    }
}
