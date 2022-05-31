namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        protected Genero Genero{get;set;}
        protected string Titulo { get; set; }
        protected string Descricao { get; set; }

        protected int Ano { get; set; }

        protected bool Excluido{get;set;}

        public Serie(int id,Genero genero,string titulo,string descricao,int ano){
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: "+this.Genero + Environment.NewLine;
            retorno += "Titulo: "+this.Titulo + Environment.NewLine;
            retorno += "Descrição: "+this.Descricao + Environment.NewLine;
            retorno += "Ano: "+this.Ano + Environment.NewLine;
            retorno += "Excluido: "+this.Excluido;
            return retorno;
        }

        public string retornoTitulo(){
            return this.Titulo;
        }
        public int retornaId(){
            return this.Id;
        }
        public bool retornaExcluido(){
            return this.Excluido;
        }
        public void Excluir(){
            this.Excluido = true;
        }
    }
}