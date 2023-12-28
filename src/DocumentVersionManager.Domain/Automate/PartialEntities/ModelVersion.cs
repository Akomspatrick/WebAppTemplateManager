using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class ModelVersion  : BaseEntity
    {
        private ModelVersion(){}
        public int ModelVersionId    { get; init; } 
        public string VersionDescription    { get; init; }  = string.Empty; 
        public string ModelVersionName    { get; init; }  = string.Empty; 
        public Model Models    { get; init; } 
        public string ModelName    { get; init; }  = string.Empty; 
        public string DefaultTestingMode    { get; init; }  = string.Empty; 
        public DateTime Timestamp    { get; init; } 
        public string UserName    { get; init; }  = string.Empty; 
        private  List <Document> _Documents { get;  set;}  = new List<Document>();
        public  IReadOnlyCollection<Document> Documents => _Documents;
        private  List <Product> _Products { get;  set;}  = new List<Product>();
        public  IReadOnlyCollection<Product> Products => _Products;
        public int Capacity    { get; init; } 
        public Double NominalOutput    { get; init; } 
        public decimal NominalOutputPercentage    { get; init; } 
        public decimal NonlinearityPercentage    { get; init; } 
        public int MinimumDeadLoad    { get; init; } 
        public Double vMin    { get; init; } 
        public int nMax    { get; init; } 
        public int SafeLoad    { get; init; } 
        public int UltimateLoad    { get; init; } 
        public string ShellMaterialName    { get; init; }  = string.Empty; 
        public Boolean Alloy    { get; init; } 
        public int DefaultCableLength    { get; init; } 
        public int NumberOfGauges    { get; init; } 
        public int Resistance    { get; init; } 
        public string CCNumber    { get; init; }  = string.Empty; 
        public string AccuracyClass    { get; init; }  = string.Empty; 
        public string Application    { get; init; }  = string.Empty; 
        public int TemperingHardnessLow    { get; init; } 
        public int TemperingHardnessHigh    { get; init; } 
        public string NTEPCertificationId    { get; init; }  = string.Empty; 
        public DateTime NTEPCertificationTimestamp    { get; init; } 
        public string OIMLCertificationId    { get; init; }  = string.Empty; 
        public DateTime OIMLCertificationTimestamp    { get; init; } 
        public Boolean TestPointDirection    { get; init; } 
        public ShellMaterial ShellMaterial    { get; init; } 
        private  List <TestPoint> _TestPoints { get;  set;}  = new List<TestPoint>();
        public  IReadOnlyCollection<TestPoint> TestPoints => _TestPoints;
        public Guid GuidId    { get; init; } 
        
        public static ModelVersion Create(int  modelVersionId, string  versionDescription, string  modelVersionName, string  modelName, string  defaultTestingMode, DateTime  timestamp, string  userName, int  capacity, Double  nominalOutput, decimal  nominalOutputPercentage, decimal  nonlinearityPercentage, int  minimumDeadLoad, Double  vMin, int  nMax, int  safeLoad, int  ultimateLoad, string  shellMaterialName, Boolean  alloy, int  defaultCableLength, int  numberOfGauges, int  resistance, string  cCNumber, string  accuracyClass, string  application, int  temperingHardnessLow, int  temperingHardnessHigh, string  nTEPCertificationId, DateTime  nTEPCertificationTimestamp, string  oIMLCertificationId, DateTime  oIMLCertificationTimestamp, Boolean  testPointDirection, Guid  guidId)
    {
    if (guidId == Guid.Empty)
    {
        throw new ArgumentException($"ModelVersion Guid value cannot be empty {nameof(guidId)}");
    }
        return  new()
        {
            ModelVersionId = modelVersionId ,
            VersionDescription = versionDescription ,
            ModelVersionName = modelVersionName ,
            ModelName = modelName ,
            DefaultTestingMode = defaultTestingMode ,
            Timestamp = timestamp ,
            UserName = userName ,
            Capacity = capacity ,
            NominalOutput = nominalOutput ,
            NominalOutputPercentage = nominalOutputPercentage ,
            NonlinearityPercentage = nonlinearityPercentage ,
            MinimumDeadLoad = minimumDeadLoad ,
            vMin = vMin ,
            nMax = nMax ,
            SafeLoad = safeLoad ,
            UltimateLoad = ultimateLoad ,
            ShellMaterialName = shellMaterialName ,
            Alloy = alloy ,
            DefaultCableLength = defaultCableLength ,
            NumberOfGauges = numberOfGauges ,
            Resistance = resistance ,
            CCNumber = cCNumber ,
            AccuracyClass = accuracyClass ,
            Application = application ,
            TemperingHardnessLow = temperingHardnessLow ,
            TemperingHardnessHigh = temperingHardnessHigh ,
            NTEPCertificationId = nTEPCertificationId ,
            NTEPCertificationTimestamp = nTEPCertificationTimestamp ,
            OIMLCertificationId = oIMLCertificationId ,
            OIMLCertificationTimestamp = oIMLCertificationTimestamp ,
            TestPointDirection = testPointDirection ,
            GuidId = guidId ,
        };
    }
    }
}