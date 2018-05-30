using CodeITAirLines.Tripulantes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeITAirLines.Jogo
{
    public class Validacoes
    {
        private const string FALHA = "FALHA";
        public List<string> ListaIdTripulantes { get; set; }

        public Validacoes()
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

        public string ValidarDados(char[] caracteres, out List<string> passageiros)
        {
            passageiros = new List<string>();

            if (caracteres.Length != 3)
                return FALHA;

            var resposta = new string(caracteres);
            var passageirosLocais = resposta.Split(';').ToList();

            if (passageirosLocais.First() == passageirosLocais.Last())
                return FALHA;

            var primeiroPassageiro = ListaIdTripulantes.Exists(x => x.Equals(passageirosLocais.First()));
            var segundoPassageiro = ListaIdTripulantes.Exists(x => x.Equals(passageirosLocais.Last()));

            if (!primeiroPassageiro || !segundoPassageiro)
                return FALHA;

            passageiros = passageirosLocais;

            return "P";
        }
    }
}