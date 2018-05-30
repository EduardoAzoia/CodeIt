using CodeITAirLines.Jogo;

namespace CodeITAirLines
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new AcoesFactory().Obter().Jogar();
        }
    }
}