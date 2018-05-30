using System.Collections.Generic;

namespace CodeITAirLines.Veiculo
{
    public interface ISmartForTwo
    {
        string Localizacao { get; set; }

        string SmartForTwoIndo { get; }

        string SmartForTwoVoltando { get; }

        void TrafegarPassageiros(List<string> caracteres);
    }
}