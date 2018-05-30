using CodeITAirLines.Veiculo;
using System.Collections.Generic;

namespace CodeITAirLines.Jogo.Interfaces
{
    public interface IBuilderTexto
    {
        void LancarMensagemDeAtencao(string mensagem, string titulo);

        void LancarMensagemInformativa(string mensagem, string titulo);

        string LocalizarPassageiros(List<Passageiro> passageiros);

        string LocalizarSmartForTwo(ISmartForTwo smartForTwo);
    }
}