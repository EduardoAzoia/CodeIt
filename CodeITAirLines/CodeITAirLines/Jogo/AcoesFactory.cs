using CodeITAirLines.Jogo.Interfaces;
using CodeITAirLines.Tripulantes;
using CodeITAirLines.Veiculo;

namespace CodeITAirLines.Jogo
{
    public class AcoesFactory
    {
        public IAcoes Obter()
        {
            var builderPassageiros = new BuilderPassageiros();
            var builderTexto = new BuilderTexto(builderPassageiros);
            var smartForTwo = new SmartForTwoFactory().Obter(builderPassageiros, builderTexto);

            return new Acoes(new Instrucoes(builderTexto),
                             builderPassageiros,
                             smartForTwo,
                             builderTexto,
                             new ValidacoesDados());
        }
    }
}