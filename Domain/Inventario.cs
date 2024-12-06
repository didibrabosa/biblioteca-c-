namespace Biblioteca.Entidades
{
    public class Inventario
    {
        public int Id {get; set;} 
        public int LivroId {get; set;}
        public int Quantidade {get; set;} = int.MaxValue;
        public string Estado {get; set;} = string.Empty;

        public Inventario() { }
        
        public Inventario(int id, int livroId, int quantidade, string estado)
        {
            Id = id;
            LivroId = livroId;
            Quantidade = quantidade;
            Estado = estado;     
        }
    }
}