using CodeITAirLines.Aeroporto;
using CodeITAirLines.Veiculo;
using System.Collections.Generic;
using System.Linq;

namespace CodeITAirLines.Tripulantes
{
    public class Validacoes
    {
        private const string SEM_MOTORISTAS = "Os tripulantes {0} e {1}, não estão capacitados para operarem o SmartForTwo.";
        private const string SEM_MOTORISTA = "Os tripulante {0} não está capacitado para operar o SmartForTwo.";
        private const string SEM_SUPERIOR = "Os tripulantes {0} e {1}, não podem ficar a sós.";

        public bool ValidarHierarquias(List<Passageiro> passageiros, out string mensagem)
        {
            mensagem = string.Empty;

            var aeroporto = passageiros.Select(x => x).Where(x => x.Localizacao == Localizacoes.AEROPORTO).ToList();
            var aviao = passageiros.Select(x => x).Where(x => x.Localizacao == Localizacoes.AVIAO).ToList();

            mensagem = ValidarHierarquias(aeroporto);
            mensagem += ValidarHierarquias(aviao);

            if (!string.IsNullOrWhiteSpace(mensagem))
                return false;

            return true;
        }

        private string ValidarHierarquias(List<Passageiro> passageiros)
        {
            if (passageiros.Count == 1)
                return string.Empty;

            var mensagem = string.Empty;
            var superior = false;
            var naoParceiro = false;
            var existePolicial = passageiros.Exists(x => x is Policial);

            foreach (var primeiroPassageiro in passageiros)
            {
                if (primeiroPassageiro.Dirigir.Equals(true))
                    continue;

                foreach (var segundoPassageiro in passageiros)
                {
                    if (primeiroPassageiro.Equals(segundoPassageiro))
                        continue;

                    if (!superior)
                    {
                        var superiores = primeiroPassageiro.ObterSuperior();
                        superior = superiores.Exists(x => x.Equals(segundoPassageiro.GetType()));
                    }

                    if (!naoParceiro)
                    {
                        var naoParceiros = primeiroPassageiro.ObterNaoParceiros();
                        naoParceiro = naoParceiros.Exists(x => x.Equals(segundoPassageiro.GetType()));

                        if (segundoPassageiro is Presidiario)
                            naoParceiro = !existePolicial;

                        if (naoParceiro)
                            mensagem = string.Format(SEM_SUPERIOR, primeiroPassageiro.Nome, segundoPassageiro.Nome);
                    }
                }

                if (!superior && naoParceiro)
                    return mensagem;

                superior = false;
                naoParceiro = false;
            }

            return string.Empty;
        }

        public bool ValidarHieraquias(Passageiro primeiroPassageiro, Passageiro segundoPassageiro)
        {
            var primeirosSuperiores = primeiroPassageiro.ObterParceiros();

            if (primeirosSuperiores.Exists(x => x.Equals(segundoPassageiro.GetType())))
                return true;

            var segundosSuperiores = segundoPassageiro.ObterParceiros();

            if (segundosSuperiores.Exists(x => x.Equals(primeiroPassageiro.GetType())))
                return true;

            return false;
        }

        public string ValidarTripulantes(List<Passageiro> passageiros)
        {
            var primeiroPassageiro = passageiros.First();
            var segundoPassageiro = passageiros.Last();

            if (!ExisteMotorista(passageiros))
                return string.Format(SEM_MOTORISTAS, primeiroPassageiro.Nome, segundoPassageiro.Nome);

            var exiteSuperior = ValidarHieraquias(primeiroPassageiro, segundoPassageiro);

            if (!exiteSuperior)
                return string.Format(SEM_SUPERIOR, primeiroPassageiro.Nome, segundoPassageiro.Nome);

            return string.Empty;
        }

        public string ValidarTripulante(List<Passageiro> passageiro)
        {
            var primeiroPassageiro = passageiro.First();

            if (!ExisteMotorista(passageiro))
                return string.Format(SEM_MOTORISTA, primeiroPassageiro.Nome);

            return string.Empty; ;
        }

        private bool ExisteMotorista(List<Passageiro> passageiros)
        {
            return passageiros.Exists(x => x.Dirigir.Equals(true));
        }

        public bool PassageirosProximosAoVeiculo(List<Passageiro> passageiros, string localizacao, out string mensagem)
        {
            mensagem = string.Empty;

            if (passageiros.Exists(x => x.Localizacao != localizacao))
            {
                mensagem = "Os passageiros devem estar próximo ao veículo!";
                return false;
            }

            return true;
        }
    }
}