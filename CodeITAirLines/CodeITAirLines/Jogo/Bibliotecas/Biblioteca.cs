namespace CodeITAirLines.Jogo
{
    public static class Biblioteca
    {
        #region CABECALHO

        public const string CABECALHO = @"                                         ___________
                                              |
                                         _   _|_   _
                                        (_)-/   \-(_)
             _                             /\___/\                             _
            (_)___________________Bem vindo a CodeAirLines!___________________(_)
                                           \_____/";

        #endregion CABECALHO

        #region PREFACIO

        public const string PREFACIO = @"

Seu objetivo aqui é transportar uma tripulação de 8 pessoas que estão no aeroporto até um avião:

- Capitão (0);
- 1º Oficial (1);
- 2º Oficial (2);
- Chefe de Voo (3);
- 1ª Comissária de Bordo (4);
- 2ª Comissária de Bordo (5);
- Policial (6);
- Presidiário (7).";

        #endregion PREFACIO

        #region REGRAS

        public const string REGRAS = @"

Existem cinco regras para o transporte dos mesmos:

- 1ª O Capitão não pode ficar a sós com as Comissárias de Bordo;
- 2ª O Chefe de Voo não pode ficar a sós com os Oficiais;
- 3ª Apenas o Policial pode ficar a sós com o Presidiário;
- 4ª As pessoas só podem ser transportadas através de um SmartForTwo, com apens dois lugares (motorista e passageiro);
- 5ª Apenas o Capitão, Chefe de Voo e o Policial podem pilotar o SmartForTwo.

Como jogar:

- Digite a siglas daqueles que forem entrar no veículo, como no exemplo abaixo
  Ex: 0;1 - 0 para o Capitão e 1 para 1º Oficial ou 0 - para apenas o Capitão";

        #endregion REGRAS

        #region OPCOES

        public const string OPCOES = @"

Opcões:
- Digite quem vai para o SmartForTwo, ex: 0;1;
- Digite 'R' para ler as regras novamente
- Digite 'X' para sair do jogo";

        #endregion OPCOES

        #region INICIO_JOGO

        public const string INICIAR_JOGO = "\nPara iniciar o jogo aperte a tecla 'S' para continuar 'N' para finalizar o jogo!";

        #endregion INICIO_JOGO

        #region FIM_DE_JOGO

        public const string FIM_DE_JOGO = @"

                                \ /                       \ /
                           x----oOo----x FIM DE JOGO x----oOo----x";

        #endregion FIM_DE_JOGO

        #region MENSAGENS_GERAIS

        public const string FALHA = "FALHA";
        public const string INICIAR_TRANSPORTE = "P";
        public const string MOSTRAR_REGRAS = "R";
        public const string SAIR = "X";
        public const string VIOLACAO = "Violação das regras da empresa";
        public const string SEM_MOTORISTAS = "Os tripulantes {0}, não estão capacitados para operarem o SmartForTwo.";
        public const string SEM_MOTORISTA = "O tripulante {0} não está capacitado para operar o SmartForTwo.";
        public const string SEM_SUPERIOR = "Os tripulantes {0}, não podem ficar a sós.\n";
        public const string LONGE_DO_CARRO = "Os passageiros devem estar próximo ao veículo!";
        public const string ATENCAO = "Atenção";
        public const string OPERACAO_INVALIDA = "Operação inválida";
        public const string UMA_DAS_OPCOES = "Digite uma das opções citadas abaixo:";
        public const string PARABENIZAR = "Parabéns, você conseguiu levar toda a tripulação em segurança!!!";
        public const string PARABENS = "Parabéns";

        #endregion MENSAGENS_GERAIS
    }
}