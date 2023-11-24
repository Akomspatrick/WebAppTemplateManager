using DocumentVersionManager.DomainBase.Base;


namespace DocumentVersionManager.Domain.Entities
{

    public partial class Specification : BaseEntity
    {

        public static Specification Create(Guid capacitySpecificationGuid, string modelName, int modelVersionId, int capacity, DateTime timestamp, string username, double nominalOutput, decimal nominalOutputPercentage, decimal nonlinearityPercentage, int minimumDeadLoad, double vMin, int nMax, int safeLoad, int ultimateLoad, string shellMaterialName, bool alloy, int defaultCableLength, int tempRangeLow, int tempRangeHigh, int numberOfGauges, int resistance, string cCNumber, string theclass, string application, int numberInBasket, double austenitizationTemperatureInF, int austenitizationTimeInSeconds, int austenitizationHardnessLow, int austenitizationHardnessHigh, double temperingTemperatureInF, int temperingTimeInSeconds, int temperingHardnessLow, int temperingHardnessHigh, bool hasScrews, string nTEPCertificationId, DateTime nTEPCertificationTimestamp, string oIMLCertificationId, DateTime oIMLCertificationTimestamp)
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
                TempRangeLow = tempRangeLow,
                TempRangeHigh = tempRangeHigh,
                NumberOfGauges = numberOfGauges,
                Resistance = resistance,
                CCNumber = cCNumber,
                Class = theclass,
                Application = application,
                NumberInBasket = numberInBasket,
                AustenitizationTemperatureInF = austenitizationTemperatureInF,
                AustenitizationTimeInSeconds = austenitizationTimeInSeconds,
                AustenitizationHardnessLow = austenitizationHardnessLow,
                AustenitizationHardnessHigh = austenitizationHardnessHigh,
                TemperingTemperatureInF = temperingTemperatureInF,
                TemperingTimeInSeconds = temperingTimeInSeconds,
                TemperingHardnessLow = temperingHardnessLow,
                TemperingHardnessHigh = temperingHardnessHigh,
                HasScrews = hasScrews,
                NTEPCertificationId = nTEPCertificationId,
                NTEPCertificationTimestamp = nTEPCertificationTimestamp,
                OIMLCertificationId = oIMLCertificationId,
                OIMLCertificationTimestamp = oIMLCertificationTimestamp
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
             oldCS.TempRangeLow,
             oldCS.TempRangeHigh,
             oldCS.NumberOfGauges,
             oldCS.Resistance,
             oldCS.CCNumber,
             oldCS.Class,
             oldCS.Application,
             oldCS.NumberInBasket,
             oldCS.AustenitizationTemperatureInF,
             oldCS.AustenitizationTimeInSeconds,
             oldCS.AustenitizationHardnessLow,
             oldCS.AustenitizationHardnessHigh,
             oldCS.TemperingTemperatureInF,
             oldCS.TemperingTimeInSeconds,
             oldCS.TemperingHardnessLow,
             oldCS.TemperingHardnessHigh,
             oldCS.HasScrews,
             oldCS.NTEPCertificationId,
             oldCS.NTEPCertificationTimestamp,
             oldCS.OIMLCertificationId,
             oldCS.OIMLCertificationTimestamp
 );
    }
}