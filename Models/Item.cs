namespace Catalogo1.Models
{
    public class Item
    {
        public int Id { get; set; } 
        public string Titulo { get; set; } 
        public string Genero { get; set; } 
        public int Ano { get; set; } 
        public string Consola { get; set; } 
        public string Descripcion { get; set; }  
        //Nueva propiedad para la imagen 
        public string ImagenUrl { get; set; }
    }
}
