// See https://aka.ms/new-console-template for more information
using tabuleiro;
using xadrez;

Tabuleiro tab = new Tabuleiro(8, 8);

tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));

Tela.ImprimirTabuleiro(tab);
Console.ReadLine();
