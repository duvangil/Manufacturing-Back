using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Helpers
{
    public static class ProductStates
    {
        public const string InStock = "En stock";
        public const string OutOfStock = "Salido";
        public const string Defective = "Defectuoso";

        public static List<string> All => new() { InStock, OutOfStock, Defective };
    }
}
