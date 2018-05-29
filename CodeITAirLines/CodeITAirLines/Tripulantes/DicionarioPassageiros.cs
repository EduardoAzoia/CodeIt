using CodeITAirLines.Aeroporto;
using CodeITAirLines.Tripulantes.TribulacaoCabine;
using CodeITAirLines.Tripulantes.TripulacaoTecninca;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Tripulantes
{
    public class DicionarioPassageiros
    {
        public Dictionary<int, Passageiro> ObterPassageiros()
        {
            return new Dictionary<int, Passageiro>
            {
                { (int)TripulantesVoo.Piloto, ObterNovoPiloto() },
                { (int)TripulantesVoo.PrimeiroOficial, ObterNovoOficial() },
                { (int)TripulantesVoo.SegundoOficial, ObterNovoOficial() },
                { (int)TripulantesVoo.ChefeVoo, ObterNovoChefeVoo() },
                { (int)TripulantesVoo.PrimeiraComissaria, ObterNovaComissaria() },
                { (int)TripulantesVoo.SegundaComissaria, ObterNovaComissaria() },
                { (int)TripulantesVoo.Policial, ObterNovoPolicial() },
                { (int)TripulantesVoo.Presidiario, ObterNovoPresidiario() }
            };
        }

        public Dictionary<int, string> ObterNomes()
        {
            return new Dictionary<int, string>
            {
                { (int)TripulantesVoo.Piloto, "Piloto" },
                { (int)TripulantesVoo.PrimeiroOficial, "Primeiro Oficial" },
                { (int)TripulantesVoo.SegundoOficial, "Segundo Oficial" },
                { (int)TripulantesVoo.ChefeVoo, "Chefe de Voo" },
                { (int)TripulantesVoo.PrimeiraComissaria, "Primeira Comissária" },
                { (int)TripulantesVoo.SegundaComissaria, "Segunda Comissária" },
                { (int)TripulantesVoo.Policial, "Policial" },
                { (int)TripulantesVoo.Presidiario, "Presidiário" }
            };
        }

        public Passageiro ObterPassageiro(int tripulante)
        {
            return ObterPassageiros()[tripulante];
        }
        
        public Piloto ObterNovoPiloto()
        {
            return new Piloto { Localizacao = Localizacoes.AEROPORTO };
        }
        public Oficial ObterNovoOficial()
        {
            return new Oficial { Localizacao = Localizacoes.AEROPORTO };
        }

        public ChefeVoo ObterNovoChefeVoo()
        {
            return new ChefeVoo { Localizacao = Localizacoes.AEROPORTO };
        }

        public Comissaria ObterNovaComissaria()
        {
            return new Comissaria { Localizacao = Localizacoes.AEROPORTO };
        }

        public Policial ObterNovoPolicial()
        {
            return new Policial { Localizacao = Localizacoes.AEROPORTO };
        }

        public Presidiario ObterNovoPresidiario()
        {
            return new Presidiario { Localizacao = Localizacoes.AEROPORTO };
        }
    }
}
