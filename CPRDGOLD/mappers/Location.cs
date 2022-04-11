using CPRDGOLD.models;
using DBMS;
using SqlKata.Execution;
using System;
using Util;

namespace CPRDGOLD.mappers
{
    internal class Location : Mapper<Location>
    {
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public long location_id { get; set; }
        public string location_source_value { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

        protected override void LoadData(dynamic refSource = null)
        {
            string[] cols = new string[] { "location_id", "location_source_value" };
            DB.Target.CopyBinaryRows<Location>(cols, (row, write) =>
            {
                LoopRegions(practice =>
                {
                    row();
                    write(practice.region);
                    write(Enum.IsDefined(typeof(LocationType), (int)practice.region) ? ((LocationType)(int)practice.region).GetStringValue() : "Missing");
                });
            });
        }

        private void LoopRegions(Action<Practice> loadRegion)
        {
            DB.Source.RunFactory("practice", (query, schema_name) =>
            {
                var practices = query.GroupBy("region").Select("region").Get<Practice>();
                foreach (var practice in practices) loadRegion(practice);
            });
        }
    }

    internal enum LocationType
    {
        [StringValue("North East")]
        NORTH_EAST = 1,
        [StringValue("North West")]
        NORTH_WEST = 2,
        [StringValue("Yorkshire The Humber")]
        YORKSHIRETHE_HUMBER = 3,
        [StringValue("East Midlands")]
        EAST_MIDLANDS = 4,
        [StringValue("West Midlands")]
        WEST_MIDLANDS = 5,
        [StringValue("East of England")]
        EAST_OF_ENGLAND = 6,
        [StringValue("South West")]
        SOUTH_WEST = 7,
        [StringValue("South Central")]
        SOUTH_CENTRAL = 8,
        [StringValue("London")]
        LONDON = 9,
        [StringValue("South East Coast")]
        SOUTH_EAST_COAST = 10,
        [StringValue("Northern Ireland")]
        NORTHERN_IRELAND = 11,
        [StringValue("Scotland")]
        SCOTLAND = 12,
        [StringValue("Wales")]
        WALES = 13,
    }
}
