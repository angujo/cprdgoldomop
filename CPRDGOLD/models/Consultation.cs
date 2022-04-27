using System;

namespace CPRDGOLD.models
{
    internal class Consultation : ChunkedModel
    {
        public int consid { get; set; }
        public short constype { get; set; }
        public long duration { get; set; }
        public DateTime eventdate { get; set; }
        public long id { get; set; }
        public long patid { get; set; }
        public long staffid { get; set; }
        public long consult_row { get; set; }
        public DateTime sysdate { get; set; }
        public long care_site_id { get { return staffid.ToString().Length > 5 && long.TryParse(staffid.ToString().Substring(staffid.ToString().Length - 5), out long csid) ? csid : default; } }
        public long chunk_identifier { get { return ChunkIdentifier(eventdate); } }
    }
}
