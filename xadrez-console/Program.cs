// See https://aka.ms/new-console-template for more information
using tabuleiro;
using xadrez;
try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.terminada)
    {
        try
        {
            Console.Clear();
            Tela.ImprimirPartida(partida);


            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
            partida.ValidarPosicaoDeOrigem(origem);

            var peca = partida.tab.peca(origem);

            if (peca is null)
                throw new TabuleiroException("Não há nenhuma peça na origem selecionada !");

            bool[,] PosicoesPossiveis = peca.MovimentosPossiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tab, PosicoesPossiveis);

            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
            partida.ValidarPosicaoDeDestino(origem, destino);

            partida.RealizaJogada(origem, destino);
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
        }
    }

}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();
