using System.Collections.Generic;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    internal class ProductLoader : FullLoader<ProductLoader, Product>
    {
        public ProductLoader() : base("product")
        {
        }

        public override void ChunkData(IEnumerable<Product> items = null)
        {
            DataTableChunk(items, "prodcode");
            // ParallelChunk(sstd => new[] { $"{sstd.prodcode}" }, items);
        }

        public static Product ByProdcode(string prodcode) =>
            (!long.TryParse(prodcode, out long mc)) ? null : ByProdcode(mc);

        public static Product ByProdcode(long prodcode) => DataTableValue(new {prodcode});
    }
}