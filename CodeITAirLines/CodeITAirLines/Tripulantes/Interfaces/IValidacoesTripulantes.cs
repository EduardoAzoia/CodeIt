using CodeITAirLines.Veiculo;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes.Interfaces
{
    public interface IValidacoesTripulantes
    {
        bool ExisteMotorista(List<Passageiro> passageiros);

        bool PassageirosProximosAoVeiculo(List<Passageiro> passageiros, string localizacao, out string mensagem);

        bool ValidarHierarquias(List<Passageiro> passageiros, out string mensagem);

        string ValidarTripulante(List<Passageiro> passageiro);

        string ValidarTripulantes(List<Passageiro> passageiros);
    }
}