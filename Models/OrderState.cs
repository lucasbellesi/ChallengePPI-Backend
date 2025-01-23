using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengePPI.Backend.Models
{
    public class OrderState
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Evitar generación automática para semilla
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
