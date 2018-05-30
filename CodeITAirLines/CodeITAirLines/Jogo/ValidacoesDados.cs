using CodeITAirLines.Jogo.Interfaces;
using CodeITAirLines.Tripulantes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeITAirLines.Jogo
{
    public class ValidacoesDados : IValidacoesDados
    {
        public List<string> ListaIdTripulantes { get; set; }
        private readonly List<string> caractersPermitidos = new List<string> { Biblioteca.MOSTRAR_REGRAS, Biblioteca.SAIR };

        public ValidacoesDados()
        {
            MontarListaCaracteresPermitidos();
        }

        private void MontarListaCaracteresPermitidos()
        {
            var listaEnum = Enum.GetValues(typeof(TripulantesVoo))
                .Cast<TripulantesVoo>()
                .Select(x => Convert.ToInt64(x).ToString());

            var ListaIdTripulantes = new List<string>();

            foreach (var enumerador in listaEnum)
            {
                ListaIdTripulantes.Add(enumerador);
            }

            this.ListaIdTripulantes = ListaIdTripulantes;
        }

        public string ValdarDadosRecebidos(out List<string> passageiros)
        {
            passageiros = new List<string>();

            var resposta = Console.ReadLine().ToCharArray();

            if (resposta.ToList().Exists(x => x == ';'))
                return ValidarDados(resposta, out passageiros);
            else if (resposta.Length == 1)
            {
                var frase = resposta.First().ToString().ToUpper();

                var ehCaracterPermitido = caractersPermitidos.Exists(x => x.Equals(frase));

                if (ListaIdTripulantes.Exists(x => x.Equals(frase)))
                {
                    passageiros.Add(frase);
                    frase = "P";
                    ehCaracterPermitido = true;
                }

                return ehCaracterPermitido ? frase : Biblioteca.FALHA;
            }

            return Biblioteca.FALHA;
        }

        public string ValidarDados(char[] caracteres, out List<string> passageiros)
        {
            passageiros = new List<string>();

            if (caracteres.Length != 3)
                return Biblioteca.FALHA;

            var resposta = new string(caracteres);
            var passageirosLocais = resposta.Split(';').ToList();

            if (passageirosLocais.First() == passageirosLocais.Last())
                return Biblioteca.FALHA;

            var primeiroPassageiro = ListaIdTripulantes.Exists(x => x.Equals(passageirosLocais.First()));
            var segundoPassageiro = ListaIdTripulantes.Exists(x => x.Equals(passageirosLocais.Last()));

            if (!primeiroPassageiro || !segundoPassageiro)
                return Biblioteca.FALHA;

            passageiros = passageirosLocais;

            return "P";
        }
    }
}