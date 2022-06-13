using Dapper;
using System;
using Util;

namespace DBMS.models
{
    [Table("WorkLoad")]
    public class WorkLoad : CRUDModel<WorkLoad>
    {
        private int      _parallels = 3;
        public  string   Name              { get; set; }
        public  DateTime Releasedate       { get; set; }
        public  bool     Fileslocked       { get; set; }
        public  bool     Sourceprocessed   { get; set; }
        public  bool     Cdmloaded         { get; set; }
        public  bool     Chunkssetup       { get; set; }
        public  bool     Chunksloaded      { get; set; }
        public  bool     Cdmprocessed      { get; set; }
        public  bool     indices_loaded    { get; set; }
        public  bool     intervene         { get; set; }
        public  bool     post_chunk_loaded { get; set; }
        public  int      Chunksize         { get; set; }
        public  bool     Isrunning         { get; set; }
        public  Status   Status            { get; set; }

        public int Maxparallels
        {
            get => _parallels;
            set => _parallels = value > 1 ? value : 3;
        }

        public int Testchunkcount { get; set; }
        public int Chunkstart     { get; set; }
        public int Chunkend       { get; set; }

        public WorkLoad()
        {
            Releasedate    = DateTime.Now;
            Chunksize      = 500;
            Maxparallels   = 3;
            Testchunkcount = 0;
        }
    }
}