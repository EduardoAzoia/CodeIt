using CodeITAirLines.Veiculo;
using System.Collections.Generic;

namespace CodeITAirLines.Jogo.Interfaces
{
    public interface IInstrucoes
    {
        string EsperarRespostaCorreta(List<string> caracteres);

        void FimDeJogo();

        bool IniciarJogo();

        void MostrarInstrucoes();

        void MostrarMensagem(string mensagem);

        void MostrarMensagemLerLinha(string mensagem);

        void MostrarRegras();

        void PrefacioJogo(List<Passageiro> tripulantes, ISmartForTwo smartForTwo);
    }
}