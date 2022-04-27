using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    internal abstract class ChunkedModel
    {
        public long chunk_id { get; set; } //Actual ID of the _chunk table

        protected long ChunkIdentifier(DateTime dt) => default == dt || !long.TryParse(dt.ToString("yyyyMMdd") + chunk_id, out long dn) ? chunk_id : dn;
    }
}
