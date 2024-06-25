namespace MODELS
{
    public class DtoProducto
    {
        public int id { get; set; }
        public string CodigoBarras { get; set; }
        public string NombreProducto { get; set; }
        public int Stock { get; set; }
        public decimal PrecioUnitario { get; set; }
        
    }
}