using CPRDGOLD.models;
using System.Collections.Generic;

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
