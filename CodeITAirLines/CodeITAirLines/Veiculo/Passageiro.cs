using CodeITAirLines.Jogo;
using CodeITAirLines.Tripulantes.Interfaces;
using System;
using System.Collections.Generic;

namespace CodeITAirLines.Veiculo
{
    public abstract class Passageiro : IParceiros
    {
        public bool Dirigir { get; set; }
        public string Localizacao { get; set; }
        public string Nome { get; set; }

        public Passageiro()
        {
            Localizacao = BibliotecaLocalizacao.AEROPORTO;
        }

        public abstract List<Type> ObterNaoParceiros();

        public abstract List<Type> ObterSuperior();
    }
}