using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public override string ToString()
        {
            return "Total de linhas e colunas: "
                 + Linhas
                 + Colunas;
        }

        public Peca Peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (peca(pos) is null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= Linhas || pos.coluna < 0 || pos.coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
