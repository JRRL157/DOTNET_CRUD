using DIO.Series;

namespace DIO.Filmes
{
    public class Filme : Serie
    {
        private int Oscar;
        public Filme(int id, Genero genero, string titulo, string descricao, int ano,int oscar) : base(id, genero, titulo, descricao, ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Oscar = oscar;
        }
        public int retornaOscar(){
            return this.Oscar;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: "+this.Genero + Environment.NewLine;
            retorno += "Titulo: "+this.Titulo + Environment.NewLine;
            retorno += "Descrição: "+this.Descricao + Environment.NewLine;
            retorno += "Ano: "+this.Ano + Environment.NewLine;
            retorno += "Excluido: "+this.Excluido;
            retorno += "Oscar: "+this.Oscar;
            return retorno;
        }
    }
}