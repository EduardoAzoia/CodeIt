using CodeITAirLines.Jogo.Interfaces;
using CodeITAirLines.Tripulantes;
using CodeITAirLines.Tripulantes.Interfaces;

namespace CodeITAirLines.Veiculo
{
    public class SmartForTwoFactory
    {
        public ISmartForTwo Obter(IBuilderPassageiros builderPassageiros, IBuilderTexto builderTexto)
        {
            return new SmartForTwo(builderPassageiros, builderTexto, new ValidacoesTripulantes());
        }
    }
}