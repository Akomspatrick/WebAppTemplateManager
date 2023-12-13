using LanguageExt.ClassInstances;

namespace DocumentVersionManager.BaseModels.Entities
{

    public class Specification : BaseEntity
    {

        //public CapacitySpecification(string modelName, int modelVersionId,  int capacity, DateTime timestamp, string username, double? nominalOutput, decimal? nominalOutputPercentage, decimal? nonlinearityPercentage, int? minimumDeadLoad, double? vMin, int? nMax, int? safeLoad, int? ultimateLoad, string shellMaterial, bool alloy, int? defaultCableLength, int? tempRangeLow, int? tempRangeHigh, int? numberOfGauges, int? resistance, string cCNumber, string @class, string application, int? numberInBasket, double? austenitizationTemperatureInF, int? austenitizationTimeInSeconds, int? austenitizationHardnessLow, int? austenitizationHardnessHigh, double? temperingTemperatureInF, int? temperingTimeInSeconds, int? temperingHardnessLow, int? temperingHardnessHigh, bool hasScrews, string nTEPCertificationId, DateTime? nTEPCertificationTimestamp, string oIMLCertificationId, DateTime? oIMLCertificationTimestamp)
        //{
        //    ModelName = modelName;
        //    ModelVersionId = modelVersionId;
        //    Capacity = capacity;
        //    Timestamp = timestamp;
        //    Username = username;
        //    NominalOutput = nominalOutput;
        //    NominalOutputPercentage = nominalOutputPercentage;
        //    NonlinearityPercentage = nonlinearityPercentage;
        //    MinimumDeadLoad = minimumDeadLoad;
        //    this.vMin = vMin;
        //    this.nMax = nMax;
        //    SafeLoad = safeLoad;
        //    UltimateLoad = ultimateLoad;
        //    ShellMaterial = shellMaterial;
        //    Alloy = alloy;
        //    DefaultCableLength = defaultCableLength;
        //    TempRangeLow = tempRangeLow;
        //    TempRangeHigh = tempRangeHigh;
        //    NumberOfGauges = numberOfGauges;
        //    Resistance = resistance;
        //    CCNumber = cCNumber;
        //    Class = @class;
        //    Application = application;
        //    NumberInBasket = numberInBasket;
        //    AustenitizationTemperatureInF = austenitizationTemperatureInF;
        //    AustenitizationTimeInSeconds = austenitizationTimeInSeconds;
        //    AustenitizationHardnessLow = austenitizationHardnessLow;
        //    AustenitizationHardnessHigh = austenitizationHardnessHigh;
        //    TemperingTemperatureInF = temperingTemperatureInF;
        //    TemperingTimeInSeconds = temperingTimeInSeconds;
        //    TemperingHardnessLow = temperingHardnessLow;
        //    TemperingHardnessHigh = temperingHardnessHigh;
        //    HasScrews = hasScrews;
        //    NTEPCertificationId = nTEPCertificationId;
        //    NTEPCertificationTimestamp = nTEPCertificationTimestamp;
        //    OIMLCertificationId = oIMLCertificationId;
        //    OIMLCertificationTimestamp = oIMLCertificationTimestamp;
        //}

        public string ModelName { get; init; } = string.Empty;
        public int ModelVersionId { get; init; }
        public int Capacity { get; init; }
        public DateTime Timestamp { get; init; }
        public string UserName { get; init; } = string.Empty;
        public double? NominalOutput { get; init; }
        public decimal? NominalOutputPercentage { get; init; }
        public decimal? NonlinearityPercentage { get; init; }
        public int? MinimumDeadLoad { get; init; }
        public double? vMin { get; init; }
        public int? nMax { get; init; }
        public int? SafeLoad { get; init; }
        public int? UltimateLoad { get; init; }
        public string ShellMaterialName { get; init; } = string.Empty;
        public bool Alloy { get; init; }
        public int? DefaultCableLength { get; init; }

        public int? NumberOfGauges { get; init; }
        public int? Resistance { get; init; }
        public string CCNumber { get; init; } = string.Empty;
        public string Class { get; init; } = string.Empty;
        public string Application { get; init; }



        public int? TemperingHardnessLow { get; init; }
        public int? TemperingHardnessHigh { get; init; }

        public string NTEPCertificationId { get; init; } = string.Empty;
        public DateTime? NTEPCertificationTimestamp { get; init; }
        public string OIMLCertificationId { get; init; } = string.Empty;
        public DateTime? OIMLCertificationTimestamp { get; init; }
        public bool TestPointDirection { get; init; } = true;// true = increasing, false = decreasing
        // public Guid CapacitySpecificationGuid { get; init; }
        public ModelVersion ModelVersion { get; init; }
        public ShellMaterial ShellMaterial { get; init; }
        public ICollection<TestPoint> TestPoints { get; set; }// = new List<CapacityTestPoint>();

        public static Specification Create(Guid capacitySpecificationGuid, string modelName, int modelVersionId, int capacity,
            DateTime timestamp, string username, double? nominalOutput, decimal? nominalOutputPercentage, decimal?
            nonlinearityPercentage, int? minimumDeadLoad, double? vMin, int? nMax, int? safeLoad, int? ultimateLoad, string
            shellMaterialName, bool alloy, int? defaultCableLength,

            int? numberOfGauges,
            int? resistance, string cCNumber, string @class, string application,
           int? temperingHardnessLow,
            int? temperingHardnessHigh, string nTEPCertificationId, DateTime? nTEPCertificationTimestamp, string
            oIMLCertificationId, DateTime? oIMLCertificationTimestamp, bool testPointDirection)
        {
            return new Specification()
            {
                GuidId = capacitySpecificationGuid,
                ModelName = modelName,
                ModelVersionId = modelVersionId,
                Capacity = capacity,
                Timestamp = timestamp,
                UserName = username,
                NominalOutput = nominalOutput,
                NominalOutputPercentage = nominalOutputPercentage,
                NonlinearityPercentage = nonlinearityPercentage,
                MinimumDeadLoad = minimumDeadLoad,
                vMin = vMin,
                nMax = nMax,
                SafeLoad = safeLoad,
                UltimateLoad = ultimateLoad,
                ShellMaterialName = shellMaterialName,
                Alloy = alloy,
                DefaultCableLength = defaultCableLength,

                NumberOfGauges = numberOfGauges,
                Resistance = resistance,
                CCNumber = cCNumber,
                Class = @class,
                Application = application,

                TemperingHardnessLow = temperingHardnessLow,
                TemperingHardnessHigh = temperingHardnessHigh,

                NTEPCertificationId = nTEPCertificationId,
                NTEPCertificationTimestamp = nTEPCertificationTimestamp,
                OIMLCertificationId = oIMLCertificationId,
                OIMLCertificationTimestamp = oIMLCertificationTimestamp,
                TestPointDirection = testPointDirection
            };
        }
        public static Specification Duplicate(Specification oldCS, string authUser)

             => Create(
                oldCS.GuidId,
             oldCS.ModelName,
             oldCS.ModelVersionId,
             oldCS.Capacity,
             DateTime.Now,
             authUser,// MassloadQMS.AuthenticatedUser.ToString(),
             oldCS.NominalOutput,
             oldCS.NominalOutputPercentage,
             oldCS.NonlinearityPercentage,
             oldCS.MinimumDeadLoad,
             oldCS.vMin,
             oldCS.nMax,
             oldCS.SafeLoad,
             oldCS.UltimateLoad,
             oldCS.ShellMaterialName,
             oldCS.Alloy,
             oldCS.DefaultCableLength,

             oldCS.NumberOfGauges,
             oldCS.Resistance,
             oldCS.CCNumber,
             oldCS.Class,
             oldCS.Application,

             oldCS.TemperingHardnessLow,
             oldCS.TemperingHardnessHigh,

             oldCS.NTEPCertificationId,
             oldCS.NTEPCertificationTimestamp,
             oldCS.OIMLCertificationId,
             oldCS.OIMLCertificationTimestamp, oldCS.TestPointDirection
 );
    }
}