namespace Biblioteca.Entidades
{
    public class Inventario
    {
        public int Id {get; set;} 
        public int LivroId {get; set;}
        public int Quantidade {get; set;} = int.MaxValue;
        public string Estado {get; set;} = string.Empty;

        public Inventario(int id, int livroId, int quantidade, string estado)
        {
            Id = id;
            LivroId = livroId;
            Quantidade = quantidade;
            Estado = estado;

            if (livroId <= 0)
                throw new ArgumentException("Livro do inventário não pode ser zero ou negativo.");

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade do inventário não pode ser zero ou negativa.");

            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("Estado do inventário não pode ser vazio.");     
        }
    }
}