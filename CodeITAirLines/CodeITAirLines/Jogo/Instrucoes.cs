using CodeITAirLines.Jogo.Interfaces;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;

namespace CodeITAirLines.Jogo
{
    public class Instrucoes : IInstrucoes
    {
        private readonly IBuilderTexto builderTexto;

        public Instrucoes(IBuilderTexto builderTexto)
        {
            this.builderTexto = builderTexto;
        }

        public void MostrarInstrucoes()
        {
            MostrarMensagemLerLinha(string.Format("{0}{1}", Biblioteca.CABECALHO, Biblioteca.PREFACIO));
            MostrarMensagemLerLinha(string.Format("{0}{1}", Biblioteca.CABECALHO, Biblioteca.REGRAS));
        }

        public void MostrarRegras()
        {
            builderTexto.LancarMensagemInformativa(string.Format("{0}{1}", Biblioteca.PREFACIO, Biblioteca.REGRAS), "Regras");
        }

        public bool IniciarJogo()
        {
            Console.WriteLine(Biblioteca.INICIAR_JOGO);

            var resposta = EsperarRespostaCorreta(new List<string> { "S", "N" });

            return resposta.Equals("S");
        }

        public void PrefacioJogo(List<Passageiro> tripulantes, ISmartForTwo smartForTwo)
        {
            var localizacaoAtual = builderTexto.LocalizarPassageiros(tripulantes);
            localizacaoAtual += builderTexto.LocalizarSmartForTwo(smartForTwo);

            MostrarMensagem(string.Format("{0}{1}{2}", Biblioteca.CABECALHO, localizacaoAtual, Biblioteca.OPCOES));
        }

        public void FimDeJogo()
        {
            MostrarMensagemLerLinha(string.Format("{0}{1}", Biblioteca.CABECALHO, Biblioteca.FIM_DE_JOGO));
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.Clear();
            Console.WriteLine(mensagem);
        }

        public void MostrarMensagemLerLinha(string mensagem)
        {
            MostrarMensagem(mensagem);
            Console.Read();
        }

        public string EsperarRespostaCorreta(List<String> caracteres)
        {
            var existeNaLista = false;
            var resposta = string.Empty;

            while (!existeNaLista)
            {
                resposta = Console.ReadKey().Key.ToString().ToUpper();
                existeNaLista = caracteres.Exists(caracter => caracter.Equals(resposta));
            }

            return resposta;
        }
    }
}