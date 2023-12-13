using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelVersion  : BaseEntity
        {
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
            public string Class    { get; init; }  = string.Empty; 
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
        }
}