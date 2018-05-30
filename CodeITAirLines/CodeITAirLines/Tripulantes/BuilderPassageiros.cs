using CodeITAirLines.Tripulantes.TribulacaoCabine;
using CodeITAirLines.Tripulantes.TripulacaoTecninca;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeITAirLines.Tripulantes
{
    public class BuilderPassageiros
    {
        public List<Passageiro> ListaPassageiros { get; set; }

        public void MontarListaPassageiros()
        {
            ListaPassageiros = new List<Passageiro>
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

        public Passageiro ObterPassageiro(string valor)
        {
            var enumerador = ObterValorEnum(valor);
            var nome = ObterNomeEnum(enumerador);

            return ListaPassageiros.Select(x => x).Where(x => x.Nome.Equals(nome)).First();
        }

        public Piloto ObterNovoPiloto<T>(T valor) => new Piloto { Nome = ObterNomeEnum(valor) };

        public Oficial ObterNovoOficial<T>(T valor) => new Oficial { Nome = ObterNomeEnum(valor) };

        public ChefeVoo ObterNovoChefeVoo<T>(T valor) => new ChefeVoo { Nome = ObterNomeEnum(valor) };

        public Comissaria ObterNovaComissaria<T>(T valor) => new Comissaria { Nome = ObterNomeEnum(valor) };

        public Policial ObterNovoPolicial<T>(T valor) => new Policial { Nome = ObterNomeEnum(valor) };

        public Presidiario ObterNovoPresidiario<T>(T valor) => new Presidiario { Nome = ObterNomeEnum(valor) };

        public string ObterNomeEnum<T>(T valor) => Enum.GetName(typeof(TripulantesVoo), valor);

        public TripulantesVoo ObterValorEnum(string valor)
        {
            var enumerador = new TripulantesVoo();
            Enum.TryParse(valor, out enumerador);
            return enumerador;
        }
    }
}