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
            ParallelChunk(new List<Action<Product>>
            {
                sstd =>AddChunkByKeys(sstd,null,$"{sstd.prodcode}"),       // ProdCode
            },items);
        }

        public static Product ByProdcode(string prodcode)
        {
            return (!long.TryParse(prodcode, out long mc)) ? null : ByProdcode(mc);
        }

        public static Product ByProdcode(long prodcode)
        {
            // return GetMe().searchOne(m => m.prodcode == prodcode, $"prodcode{prodcode}") ?? new Product();
            // return GetMe().QuerySearchOne("prodcode = ?", new object[] { prodcode }, m => m.prodcode == prodcode);
            return ChunkValue(null,$"{prodcode}");
        }
    }
}
