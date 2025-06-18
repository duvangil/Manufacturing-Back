using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Entities
{
    [Table("Product", Schema = "Stock")]
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [ForeignKey("ElaborationType")]
        public Guid ElaborationTypeId { get; set; }

        public int Quantity { get; set; }


        [Required]
        public string State { get; set; } = null!; // Ej: "En stock", "Salido", "Defectuoso"
        public ElaborationType ElaborationType { get; set; } = null!;
    }

}
