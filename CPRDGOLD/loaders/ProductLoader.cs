using CPRDGOLD.models;
using DBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class ProductLoader : FullLoader<ProductLoader, Product>
    {
        public ProductLoader() : base("product") { }
        public override void ChunkData(IEnumerable<Product> items = null)
        {
            ParallelChunk(sstd => new string[] { $"{sstd.prodcode}" }, items);
        }

        public static Product ByProdcode(string prodcode) => (!long.TryParse(prodcode, out long mc)) ? null : ByProdcode(mc);

        public static Product ByProdcode(long prodcode) => ChunkValue($"{prodcode}");
    }
}
