using System;
using System.Collections.Generic;
using CadastroDeLivros.Interfaces;

namespace CadastroDeLivros
{
    public class LivrosRepositorio : IRepositorio<Livro>
    {
        private List<Livro> listaLivros = new List<Livro>();
        public void Atualizar(int id, Livro cadastro)
        {
            listaLivros[id] = cadastro;
        }

        public void Excluir(int id)
        {
            listaLivros[id].Excluir();
        }

        public void Inserir(Livro cadastro)
        {
            listaLivros.Add(cadastro);
        }

        public List<Livro> Lista()
        {
            return listaLivros;
        }

        public int ProximoId()
        {
           return listaLivros.Count;
        }

        public Livro RetornaPorId(int id)
        {
            return listaLivros[id];
        }
    }
}
