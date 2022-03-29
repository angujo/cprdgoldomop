namespace Util
{
    public enum LoadType
    {
        [StringValue("CareSite")]
        CARESITE,
        [StringValue("CdmSource")]
        CDMSOURCE,
        [StringValue("ChunkLoad")]
        CHUNKLOAD,
        [StringValue("ChunkSetup")]
        CHUNKSETUP,
        [StringValue("CohortDefinition")]
        COHORTDEFINITION,
        [StringValue("ConditionEra")]
        CONDITIONERA,
        [StringValue("ConditionOccurrence")]
        CONDITIONOCCURRENCE,
        [StringValue("CreateTables")]
        CREATETABLES,
        [StringValue("Death")]
        DEATH,
        [StringValue("DeviceExposure")]
        DEVICEEXPOSURE,
        [StringValue("DrugEra")]
        DRUGERA,
        [StringValue("DrugExposure")]
        DRUGEXPOSURE,
        [StringValue("Location")]
        LOCATION,
        [StringValue("Measurement")]
        MEASUREMENT,
        [StringValue("Observation")]
        OBSERVATION,
        [StringValue("ObservationPeriod")]
        OBSERVATIONPERIOD,
        [StringValue("Person")]
        PERSON,
        [StringValue("ProcedureExposure")]
        PROCEDUREEXPOSURE,
        [StringValue("Provider")]
        PROVIDER,
        [StringValue("SourceToSource")]
        SOURCETOSOURCE,
        [StringValue("SourceToStandard")]
        SOURCETOSTANDARD,
        [StringValue("Specimen")]
        SPECIMEN,
        [StringValue("VisitDetail")]
        VISITDETAIL,
        [StringValue("VisitOccurrence")]
        VISITOCCURRENCE,
        [StringValue("DaySupplyDecodeSetup")]
        DAYSUPPLYDECODESETUP,
        [StringValue("DaySupplyModeSetup")]
        DAYSUPPLYMODESETUP,
    }

    enum DBMSType
    {
        POSTGRESQL,
        MYSQL,
        //... others
    }

    public enum Status
    {
        SCHEDULED,
        RUNNING,
        STOPPED,
        FINISHED,
    }
}
