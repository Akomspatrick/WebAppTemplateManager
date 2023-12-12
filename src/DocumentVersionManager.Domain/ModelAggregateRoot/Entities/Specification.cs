using DocumentVersionManager.DomainBase.Base;
using LanguageExt.ClassInstances;


namespace DocumentVersionManager.Domain.Entities
{

    public partial class Specification : BaseEntity
    {


        private Specification()
        {
        }
        public static Specification Create(Guid capacitySpecificationGuid, string modelName, int modelVersionId, int capacity,
            DateTime timestamp, string username, double nominalOutput, decimal nominalOutputPercentage,
            decimal nonlinearityPercentage, int minimumDeadLoad, double vMin, int nMax, int safeLoad, int ultimateLoad,
            string shellMaterialName, bool alloy, int defaultCableLength, int numberOfGauges,
            int resistance, string cCNumber, string theclass, string application, int temperingHardnessLow, int temperingHardnessHigh,
            string nTEPCertificationId,
            DateTime nTEPCertificationTimestamp, string oIMLCertificationId, DateTime oIMLCertificationTimestamp)
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
                Class = theclass,
                Application = application,
                TemperingHardnessLow = temperingHardnessLow,
                TemperingHardnessHigh = temperingHardnessHigh,
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
             oldCS.OIMLCertificationTimestamp
 );
    }
}