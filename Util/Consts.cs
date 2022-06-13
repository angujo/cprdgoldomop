namespace Util
{
    public static class Consts
    {
        /**
         * How long should the service tick in milliseconds
         */
        public const int SERVICE_TIMER = 60000; //1 minute

        /**
         * Number of times the service should check for intervention
         * during the life of a timer.
         * E.g. If 3 and timer is 60000, service will check every 20 secs
         */
        public const int SERVICE_CHECKS = 20; // 20 = Every 3 secs

        public static readonly string SERVICE_NAME = "OMOPBuilder";

        public static readonly string SERVICE_DESC =
            "A service to run source file mapping and OMOP CDM transformation from source files.";

        public static readonly string   DATE_FORMAT    = "dd/mm/yyyy";
        public static readonly string   MED_DICT       = "Medical Dictionary";
        public static readonly string   PRD_DICT       = "Product Dictionary";
        public static readonly string[] MED_PRD_DICT   = new string[] {MED_DICT, PRD_DICT};
        public static readonly int      LOOP_LOG_COUNT = 50000; // For optimal loggin should be less than DB_CHUNK_SIZE
        public static readonly int      DB_CHUNK_SIZE  = 100000;
        public const           string   TUPLE_MISS_STR = "?";
        public const           int      TUPLE_MISS_NUM = -99;

        public const string PATIENT_CONDITION =
            "accept = 1 AND gender::int IN (1,2) AND (case when 4 > char_length(yob::varchar) then 1800+yob else yob end) >= 1875 " +
            "AND (deathdate IS null OR frd IS NULL OR deathdate >=  frd)";
    }
}