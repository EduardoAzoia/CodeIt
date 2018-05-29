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
    public class BuilderTripulantes
    {
        public List<Passageiro> ObterPassageiros()
        {
            return new List<Passageiro>
            {
                ObterNovoPiloto(TripulantesVoo.Piloto),
                ObterNovoOficial(TripulantesVoo.Primeiro_Oficial),
                ObterNovoOficial(TripulantesVoo.Segundo_Oficial),
                ObterNovoChefeVoo(TripulantesVoo.Chefe_De_Voo),
                ObterNovaComissaria(TripulantesVoo.Primeira_Comissaria),
                ObterNovaComissaria(TripulantesVoo.Segunda_Comissaria),
                ObterNovoPolicial(TripulantesVoo.Policial),
                ObterNovoPresidiario(TripulantesVoo.Presidiario)
            };
        }

        public Passageiro ObterPassageiro(int tripulante)
        {
            return ObterPassageiros()[tripulante];
        }

        public Piloto ObterNovoPiloto<T>(T valor) => new Piloto { Localizacao = Localizacoes.AEROPORTO, Nome = ObterNomeEnum(valor) };

        public Oficial ObterNovoOficial<T>(T valor) => new Oficial { Localizacao = Localizacoes.AEROPORTO, Nome = ObterNomeEnum(valor) };

        public ChefeVoo ObterNovoChefeVoo<T>(T valor) => new ChefeVoo { Localizacao = Localizacoes.AEROPORTO, Nome = ObterNomeEnum(valor) };

        public Comissaria ObterNovaComissaria<T>(T valor) => new Comissaria { Localizacao = Localizacoes.AEROPORTO, Nome = ObterNomeEnum(valor) };

        public Policial ObterNovoPolicial<T>(T valor) => new Policial { Localizacao = Localizacoes.AEROPORTO, Nome = ObterNomeEnum(valor) };

        public Presidiario ObterNovoPresidiario<T>(T valor) => new Presidiario { Localizacao = Localizacoes.AEROPORTO, Nome = ObterNomeEnum(valor) };

        public string ObterNomeEnum<T>(T valor)
        {
            return Enum.GetName(typeof(TripulantesVoo), valor);
        }

        public object ObterValorEnum(string valor)
        {
            var enumerador = new TripulantesVoo();

            Enum.TryParse(valor, out enumerador);

            return enumerador;
        }
    }
}
