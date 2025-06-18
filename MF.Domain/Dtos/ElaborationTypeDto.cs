using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Dtos
{
    public class ElaborationTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
