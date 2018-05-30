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

        public string ValidarDados(char[] caracteres, out List<string> passageiros)
        {
            try
            {
                if (caracteres.Length > 3)
                    LancarExcessao();

                var resposta = new string(caracteres);
                var passageirosLocais = resposta.Split(';').ToList();
                var listaCarateres = MontarListaCaracteresPermitidos();

                var primeiroPassageiro = listaCarateres.Exists(x => x.Equals(passageirosLocais.First()));
                var segundoPassageiro = listaCarateres.Exists(x => x.Equals(passageirosLocais.Last()));

                if (!primeiroPassageiro || !segundoPassageiro)
                    LancarExcessao();

                passageiros = passageirosLocais;

                return "P";
            }
            catch (Exception e)
            {
                passageiros = new List<string>();
                return e.ToString();
            }
        }

        private void LancarExcessao()
        {
            throw new Exception("FALHA");
        }
    }
}
