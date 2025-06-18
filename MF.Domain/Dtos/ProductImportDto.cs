using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Dtos
{
    public class ProductImportDto
    {
        public string Name { get; set; } = null!;
        public string ElaborationTypeName { get; set; } = null!;
        public int Quantity { get; set; }
        public string State { get; set; } = null!;
    }
}
