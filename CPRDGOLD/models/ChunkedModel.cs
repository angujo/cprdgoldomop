using System;

namespace CPRDGOLD.models
{
    internal abstract class ChunkedModel
    {
        public long chunk_id { get; set; } //Actual ID of the _chunk table

        protected long ChunkIdentifier(DateTime dt) => default == dt || !long.TryParse(dt.ToString("yyyyMMdd") + chunk_id, out long dn) ? chunk_id : dn;
    }
}
