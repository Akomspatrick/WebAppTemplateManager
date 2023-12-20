namespace DocumentVersionManager.BaseModels.Entities
{
    public class ModelVersion : BaseEntity
    {
        public int ModelVersionId { get; init; }

        public string VersionDescription { get; init; } = string.Empty;
        public string ModelVersionName { get; init; } = string.Empty;


        public Model Models { get; init; }
        public string ModelName { get; init; } = string.Empty;

        public string DefaultTestingMode { get; init; } = string.Empty; // Manual, Automatic for each product


        public DateTime Timestamp { get; init; }

        public string UserName { get; init; } = string.Empty;


        public ICollection<Document> Documents { get; init; }
        // public Specification Specification { get; init; }
        public ICollection<Product> Products { get; set; }

        //FROM SPECIFICATION

        //public string ModelName { get; init; } = string.Empty;
        //public int ModelVersionId { get; init; }
        public int Capacity { get; init; }
        //public DateTime Timestamp { get; init; }
        //public string UserName { get; init; } = string.Empty;
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
        public string AccuracyClass { get; init; } = string.Empty;
        public string Application { get; init; } = string.Empty;

        public int? TemperingHardnessLow { get; init; }
        public int? TemperingHardnessHigh { get; init; }

        public string NTEPCertificationId { get; init; } = string.Empty;
        public DateTime? NTEPCertificationTimestamp { get; init; }
        public string OIMLCertificationId { get; init; } = string.Empty;
        public DateTime? OIMLCertificationTimestamp { get; init; }
        public bool TestPointDirection { get; init; } = true;// true = increasing, false = decreasing

        // public ModelVersion ModelVersion { get; init; }
        public required ShellMaterial ShellMaterial { get; init; }
        public ICollection<TestPoint> TestPoints { get; set; } = new List<TestPoint>();



    }
}
