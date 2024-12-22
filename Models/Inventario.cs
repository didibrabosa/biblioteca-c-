namespace BibliotecaApp.Models
{
    public class Inventario
    {
        public int Id {get; set;}
        public int IdCatalogo {get; set;}
        public bool Disponivel{get; set; } = true;
    }
}