using System;
using System.Linq;

namespace Util
{
    public static class EnumGroups
    {
        public static readonly LoadType[] POST_LOAD_TYPES =
            {LoadType.CONDITIONERA, LoadType.DRUGERA, LoadType.P_VISIT_DETAIL}; // LoadType.DOSE_ERA, //Disable for now

        public static readonly LoadType[] INDICES_LOAD_TYPES =
        {
            LoadType.IDX_CARE_SITE, LoadType.IDX_CDM_SOURCE, LoadType.IDX_COHORT_ATTRIBUTE,
            LoadType.IDX_COHORT_DEFINITION, LoadType.IDX_COHORT,
            LoadType.IDX_CONDITION_ERA, LoadType.IDX_CONDITION_OCCURRENCE, LoadType.IDX_COST,
            LoadType.IDX_DEATH, LoadType.IDX_DEVICE_EXPOSURE, LoadType.IDX_DOSE_ERA,
            LoadType.IDX_DRUG_ERA, LoadType.IDX_DRUG_EXPOSURE, LoadType.IDX_LOCATION, LoadType.IDX_MEASUREMENT,
            LoadType.IDX_NOTE_NLP,
            LoadType.IDX_NOTE, LoadType.IDX_OBSERVATION_PERIOD,
            LoadType.IDX_PAYER_PLAN_PERIOD, LoadType.IDX_PERSON, LoadType.IDX_PROCEDURE_OCCURRENCE,
            LoadType.IDX_PROVIDER, LoadType.IDX_SPECIMEN, LoadType.IDX_VISIT_DETAIL,
            LoadType.IDX_VISIT_OCCURRENCE, LoadType.IDX_OBSERVATION,
            // /** We disable below for now */
            // LoadType.IDX_CONCEPT_ANCESTOR, LoadType.IDX_CONCEPT_CLASS, LoadType.IDX_CONCEPT_RELATIONSHIP,
            // LoadType.IDX_CONCEPT_SYNONYM, LoadType.IDX_CONCEPT, LoadType.IDX_DOMAIN,LoadType.IDX_DRUG_STRENGTH,
            // LoadType.IDX_FACT_RELATIONSHIP, LoadType.IDX_RELATIONSHIP, LoadType.IDX_VOCABULARY,
        };

        public static readonly LoadType[] ONCE_LOAD_TYPES =
        {
            LoadType.PROVIDER, LoadType.CARESITE, LoadType.LOCATION, LoadType.CDMSOURCE, LoadType.COHORTDEFINITION,
            LoadType.DAY_SUPPLY_DECODE_SETUP, LoadType.DAYSUPPLYMODESETUP,
            LoadType.SOURCETOSOURCE, LoadType.SOURCETOSTANDARD, LoadType.CREATETABLES, LoadType.CHUNKSETUP,
            LoadType.CHUNKLOAD
        };

        public static LoadType[] CHUNK_LOAD_TYPES
        {
            get
            {
                var excludes = ONCE_LOAD_TYPES.Concat(POST_LOAD_TYPES).Concat(INDICES_LOAD_TYPES);
                return Enum.GetValues(typeof(LoadType)).Cast<LoadType>().Where(lt => !excludes.Contains(lt)).ToArray();
            }
        }
    }

    public enum LoadType
    {
        /**
         * For the OMOP CDM Tables
         */
        [StringValue("CareSite")] CARESITE,
        [StringValue("CdmSource")]            CDMSOURCE,
        [StringValue("ChunkLoad")]            CHUNKLOAD,
        [StringValue("ChunkSetup")]           CHUNKSETUP,
        [StringValue("CohortDefinition")]     COHORTDEFINITION,
        [StringValue("ConditionEra")]         CONDITIONERA,
        [StringValue("ConditionOccurrence")]  CONDITIONOCCURRENCE,
        [StringValue("CreateTables")]         CREATETABLES,
        [StringValue("Death")]                DEATH,
        [StringValue("DeviceExposure")]       DEVICEEXPOSURE,
        [StringValue("DrugEra")]              DRUGERA,
        [StringValue("DrugExposure")]         DRUGEXPOSURE,
        [StringValue("Location")]             LOCATION,
        [StringValue("Measurement")]          MEASUREMENT,
        [StringValue("Observation")]          OBSERVATION,
        [StringValue("ObservationPeriod")]    OBSERVATIONPERIOD,
        [StringValue("Person")]               PERSON,
        [StringValue("ProcedureExposure")]    PROCEDUREEXPOSURE,
        [StringValue("Provider")]             PROVIDER,
        [StringValue("SourceToSource")]       SOURCETOSOURCE,
        [StringValue("SourceToStandard")]     SOURCETOSTANDARD,
        [StringValue("Specimen")]             SPECIMEN,
        [StringValue("VisitDetail")]          VISITDETAIL,
        [StringValue("VisitOccurrence")]      VISIT_OCCURRENCE,
        [StringValue("DaySupplyDecodeSetup")] DAY_SUPPLY_DECODE_SETUP,
        [StringValue("DaySupplyModeSetup")]   DAYSUPPLYMODESETUP,
        [StringValue("PostVisitDetail")]      P_VISIT_DETAIL,
        // [StringValue("DoseEra")]
        // DOSE_ERA,

        // Indexes
        [StringValue("IdxCareSite")]         IDX_CARE_SITE,
        [StringValue("IdxCdmSource")]        IDX_CDM_SOURCE,
        [StringValue("IdxCohortAttribute")]  IDX_COHORT_ATTRIBUTE,
        [StringValue("IdxCohortDefinition")] IDX_COHORT_DEFINITION,
        [StringValue("IdxCohort")]           IDX_COHORT,
        [StringValue("IdxConditionEra")]     IDX_CONDITION_ERA,

        [StringValue("IdxConditionOccurrence")]
        IDX_CONDITION_OCCURRENCE,
        [StringValue("IdxCost")]              IDX_COST,
        [StringValue("IdxDeath")]             IDX_DEATH,
        [StringValue("IdxDeviceExposure")]    IDX_DEVICE_EXPOSURE,
        [StringValue("IdxDoseEra")]           IDX_DOSE_ERA,
        [StringValue("IdxDrugEra")]           IDX_DRUG_ERA,
        [StringValue("IdxDrugExposure")]      IDX_DRUG_EXPOSURE,
        [StringValue("IdxLocation")]          IDX_LOCATION,
        [StringValue("IdxMeasurement")]       IDX_MEASUREMENT,
        [StringValue("IdxNoteNlp")]           IDX_NOTE_NLP,
        [StringValue("IdxNote")]              IDX_NOTE,
        [StringValue("IdxObservationPeriod")] IDX_OBSERVATION_PERIOD,
        [StringValue("IdxObservation")]       IDX_OBSERVATION,
        [StringValue("IdxPayerPlanPeriod")]   IDX_PAYER_PLAN_PERIOD,
        [StringValue("IdxPerson")]            IDX_PERSON,

        [StringValue("IdxProcedureOccurrence")]
        IDX_PROCEDURE_OCCURRENCE,
        [StringValue("IdxProvider")]        IDX_PROVIDER,
        [StringValue("IdxSpecimen")]        IDX_SPECIMEN,
        [StringValue("IdxVisitDetail")]     IDX_VISIT_DETAIL,
        [StringValue("IdxVisitOccurrence")] IDX_VISIT_OCCURRENCE,
        // For Vocabulary. They are set when loaded.
        // So disable for now
        // [StringValue("IdxVocabulary")]
        // IDX_VOCABULARY,
        // [StringValue("IdxConceptAncestor")]
        // IDX_CONCEPT_ANCESTOR,
        // [StringValue("IdxConceptClass")]
        // IDX_CONCEPT_CLASS,
        // [StringValue("IdxConceptRelationship")]
        // IDX_CONCEPT_RELATIONSHIP,
        // [StringValue("IdxConceptSynonym")]
        // IDX_CONCEPT_SYNONYM,
        // [StringValue("IdxConcept")]
        // IDX_CONCEPT,
        // [StringValue("IdxRelationship")]
        // IDX_RELATIONSHIP,
        // [StringValue("IdxDrugStrength")]
        // IDX_DRUG_STRENGTH,
        // [StringValue("IdxDomain")]
        // IDX_DOMAIN,
        // [StringValue("IdxFactRelationship")]
        // IDX_FACT_RELATIONSHIP,
    }

    enum DBMSType
    {
        POSTGRESQL,
        MYSQL,
        //... others
    }

    public enum Status
    {
        [StringValue("Scheduled")] SCHEDULED,
        [StringValue("Running")]   RUNNING,
        [StringValue("Stopped")]   STOPPED,
        [StringValue("Finished")]  FINISHED,
    }
}