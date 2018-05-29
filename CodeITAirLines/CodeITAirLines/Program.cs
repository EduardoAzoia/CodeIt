using CodeITAirLines.Jogo;
using CodeITAirLines.Tripulantes;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var acoes = new AcoesFactory().Obter();

            acoes.Jogar();

            acoes.instrucoes.FimDeJogo();
        }
    }
}
