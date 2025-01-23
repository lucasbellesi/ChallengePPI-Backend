using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengePPI.Backend.Models
{
    public class OrderState
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}