using CodeITAirLines.Tripulantes.TribulacaoCabine;
using CodeITAirLines.Tripulantes.TripulacaoTecninca;
using CodeITAirLines.Veiculo;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes.Interfaces
{
    public interface IBuilderPassageiros
    {
        List<Passageiro> ListaPassageiros { get; set; }

        void MontarListaPassageiros();

        string ObterNomeEnum<T>(T valor);

        Comissaria ObterNovaComissaria<T>(T valor);

        ChefeVoo ObterNovoChefeVoo<T>(T valor);

        Oficial ObterNovoOficial<T>(T valor);

        Piloto ObterNovoPiloto<T>(T valor);

        Policial ObterNovoPolicial<T>(T valor);

        Presidiario ObterNovoPresidiario<T>(T valor);

        Passageiro ObterPassageiro(string valor);

        TripulantesVoo ObterValorEnum(string valor);
    }
}