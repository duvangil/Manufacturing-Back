using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ElaborationTypeName { get; set; }

        public Guid ElaborationTypeId { get; set; }
        public string State { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? ModifyDate { get; set; }

    }
}
