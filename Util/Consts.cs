namespace Util
{
    public static class Consts
    {
        public static readonly string DATE_FORMAT = "dd/mm/yyyy";
        public static readonly string MED_DICT = "Medical Dictionary";
        public static readonly string PRD_DICT = "Product Dictionary";
        public static readonly string[] MED_PRD_DICT = new string[] { MED_DICT, PRD_DICT };
        public static readonly int LOOP_LOG_COUNT = 50000; // For optimal loggin should be less than DB_CHUNK_SIZE
        public static readonly int DB_CHUNK_SIZE = 100000;
        public const string TUPLE_MISS = "?";
    }
}
