using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using tabuleiro;

namespace xadrez
{
    public class Peao : Peca
    {

        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.DefinirValores(posicao.linha - 1, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 2, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos) && qtdMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //#jogada en passant 
                if (posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha, esquerda.coluna] = true;
                    }
                }
                if (posicao.linha == 3)
                {
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.PosicaoValida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha, direita.coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(posicao.linha + 1, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 2, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos) && qtdMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //#jogada en passant 
                if (posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha, esquerda.coluna] = true;
                    }
                }
                if (posicao.linha == 3)
                {
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.PosicaoValida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha, direita.coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
