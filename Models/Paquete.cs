
namespace MiAppMaui.Models
{
    public class Paquetes
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Destinatario { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string Estado { get; set; } = "Pendiente";
    }
}
