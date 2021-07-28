using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeLivros
{
    public class Livro : CadastroBase
    {
        //Atributos de um cadastro de livro
        private string Titulo { get; set; }
        private string Autor { get; set; }
        private Assunto Assunto { get; set; }
        private int NumPagina { get; set; }
        private float Peso { get; set; }
        private int Lancamento { get; set; }
        private bool Excluido { get; set; }

        public Livro(int id, string titulo, string autor, Assunto assunto, int numPagina, float peso, int lancamento)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Assunto = assunto;
            NumPagina = numPagina;
            Peso = peso;
            Lancamento = lancamento;
            Excluido = false;
        }

        public override string ToString()
        {
            string cadastro = "";
            cadastro += "Titulo: " + Titulo + Environment.NewLine
                + "Autor: " + Autor + Environment.NewLine
                + "Assunto: " + Assunto + Environment.NewLine
                + "Paginas: " + NumPagina + Environment.NewLine
                + "Peso: " + Peso + "g" + Environment.NewLine
                + "Lançamento: " + Lancamento + Environment.NewLine
                + "Fora de Catalogo: " + Excluido;


            return cadastro;
        }

        public string retornaTitulo()
        {
            return Titulo;
        }

        public int retornaId()
        {
            return Id;
        }

        public void Excluir()
        {
            Excluido = true;

        }

        public bool retornaExcluido()
        {
            return Excluido;
        }

    }
}
