using CodeITAirLines.Jogo;
using CodeITAirLines.Tripulantes.Interfaces;
using CodeITAirLines.Veiculo;
using System.Collections.Generic;
using System.Linq;

namespace CodeITAirLines.Tripulantes
{
    public class ValidacoesTripulantes : IValidacoesTripulantes
    {
        public bool ValidarHierarquias(List<Passageiro> passageiros, out string mensagem)
        {
            mensagem = string.Empty;

            var passageirosAeroporto = ObterPassageirosViaLocalizacao(passageiros, BibliotecaLocalizacao.AEROPORTO);
            var passageirosAviao = ObterPassageirosViaLocalizacao(passageiros, BibliotecaLocalizacao.AVIAO);

            mensagem = ValidarHierarquias(passageirosAeroporto);
            mensagem += ValidarHierarquias(passageirosAviao);

            if (!string.IsNullOrWhiteSpace(mensagem))
                return false;

            return true;
        }

        private List<Passageiro> ObterPassageirosViaLocalizacao(List<Passageiro> passageiros, string localicazao)
        {
            return passageiros.Select(x => x).Where(x => x.Localizacao == localicazao).ToList();
        }

        private string ValidarHierarquias(List<Passageiro> passageiros)
        {
            if (passageiros.Count == 1)
                return string.Empty;

            var mensagem = string.Empty;
            var superior = false;
            var naoParceiro = false;
            var existePolicial = ExistePolicial(passageiros);

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
                        superior = ExisteSuperior(primeiroPassageiro, segundoPassageiro);
                    }

                    if (!naoParceiro)
                    {
                        naoParceiro = EhNaoParceiros(primeiroPassageiro, segundoPassageiro, existePolicial);
                        mensagem = naoParceiro ? string.Format(Biblioteca.SEM_SUPERIOR, string.Join(" e ", primeiroPassageiro.Nome, segundoPassageiro.Nome)) : mensagem;
                    }
                }

                if (!superior && naoParceiro)
                    return mensagem;

                superior = false;
                naoParceiro = false;
            }

            return string.Empty;
        }

        private bool ExisteSuperior(Passageiro primeiroPassageiro, Passageiro segundoPassageiro)
        {
            var superiores = primeiroPassageiro.ObterSuperior();
            return superiores.Exists(x => x.Equals(segundoPassageiro.GetType()));
        }

        private bool EhNaoParceiros(List<Passageiro> passageiros)
        {
            var existePolicial = ExistePolicial(passageiros);
            var ehNaoParceiro = true;

            foreach (var primeiroPassageiro in passageiros)
            {
                foreach (var segundoPassageiro in passageiros)
                {
                    if (primeiroPassageiro.Equals(segundoPassageiro))
                        continue;

                    ehNaoParceiro = EhNaoParceiros(primeiroPassageiro, segundoPassageiro, existePolicial);
                }
            }

            return ehNaoParceiro;
        }

        private bool EhNaoParceiros(Passageiro primeiroPassageiro, Passageiro segundoPassageiro, bool existePolicial)
        {
            bool ehNaoParceiro = false;

            var naoParceiros = primeiroPassageiro.ObterNaoParceiros();
            ehNaoParceiro = naoParceiros.Exists(x => x.Equals(segundoPassageiro.GetType()));

            if (segundoPassageiro is Presidiario)
                ehNaoParceiro = !existePolicial;

            return ehNaoParceiro;
        }

        public string ValidarTripulantes(List<Passageiro> passageiros)
        {
            var nomes = string.Join(" e ", passageiros.Select(x => x.Nome));

            if (!ExisteMotorista(passageiros))
                return string.Format(Biblioteca.SEM_MOTORISTAS, nomes);
            
            if (EhNaoParceiros(passageiros))
                return string.Format(Biblioteca.SEM_SUPERIOR, nomes);

            return string.Empty;
        }

        private bool ExistePolicial(List<Passageiro> passageiros)
        {
            return passageiros.Exists(x => x is Policial);
        }

        public string ValidarTripulante(List<Passageiro> passageiro)
        {
            var primeiroPassageiro = passageiro.First();

            if (!ExisteMotorista(passageiro))
                return string.Format(Biblioteca.SEM_MOTORISTA, primeiroPassageiro.Nome);

            return string.Empty;
        }

        public bool ExisteMotorista(List<Passageiro> passageiros)
        {
            return passageiros.Exists(x => x.Dirigir.Equals(true));
        }

        public bool PassageirosProximosAoVeiculo(List<Passageiro> passageiros, string localizacao, out string mensagem)
        {
            mensagem = string.Empty;

            if (passageiros.Exists(x => x.Localizacao != localizacao))
            {
                mensagem = Biblioteca.LONGE_DO_CARRO;
                return false;
            }

            return true;
        }
    }
}