using CodeITAirLines.Tripulantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeITAirLines.Jogo
{
    public class Validacoes
    {
        private List<string> MontarListaCaracteresPermitidos()
        {
            var listaEnum = Enum.GetValues(typeof(TripulantesVoo));
            var listaRetorno = new List<string>();

            foreach (var enumerador in listaEnum)
            {
                listaRetorno.Add(enumerador.ToString());
            }

            return listaRetorno;
        }

        public string ValidarDados(List<char> caracteres, out List<string> passageiros)
        {
            try
            {
                return ValidarCaracteres(caracteres, out passageiros);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                passageiros = new List<string>();

                return "Falha";
            }
        }

        private string ValidarCaracteres(List<char> caracteres, out List<string> passageiros)
        { 
            if (caracteres.Count > 3)
                LancarExcessao();

            var resposta = caracteres.ToString();

            var passageirosLocais = resposta.Split(';').ToList();

            var listaCarateres = MontarListaCaracteresPermitidos();

            var primeiroPassageiro = listaCarateres.Exists(x => x.Equals(passageirosLocais.First()));
            var segundoPassageiro = listaCarateres.Exists(x => x.Equals(passageirosLocais.Last()));

            if (!primeiroPassageiro || !segundoPassageiro)
                LancarExcessao();

            passageiros = passageirosLocais;

            return "P";
        }

        private void LancarExcessao()
        {
            throw new Exception("Solicitação inválida, dúvidas consultar as regras!");
        }
    }
}
