using System.Collections.Generic;

namespace CodeITAirLines.Jogo.Interfaces
{
    public interface IValidacoesDados
    {
        List<string> ListaIdTripulantes { get; set; }

        string ValdarDadosRecebidos(out List<string> passageiros);

        string ValidarDados(char[] caracteres, out List<string> passageiros);
    }
}