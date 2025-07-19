
using System;
using System.ComponentModel.DataAnnotations;

namespace ServidorWeb.Client.ModelsLocal
{

public class FacturaLocal
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Cliente { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public DateTime? Fecha { get; set; } = DateTime.Today;
        public bool IsSynced { get; set; } = false;
    }

}
