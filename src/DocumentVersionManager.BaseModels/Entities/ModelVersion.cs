using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    // [BaseModelsForeignKeyAttribute("Model", "ModelVersions")]
    public class ModelVersion : BaseEntity
    {
        [BaseModelBasicAttribute(true, true)]
        public int ModelVersionId { get; init; }

        public string VersionDescription { get; init; } = string.Empty;

        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string ModelVersionName { get; init; } = string.Empty;
        public Model Models { get; init; }

        [BaseModelBasicAttribute(32, 0, true, true, false)]
        public string ModelName { get; init; } = string.Empty;

        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string DefaultTestingMode { get; init; } = string.Empty; // Manual, Automatic for each product


        public DateTime Timestamp { get; init; }
        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string UserName { get; init; } = string.Empty;


        public ICollection<Document> Documents { get; init; }

        public ICollection<Product> Products { get; set; }


        public int Capacity { get; init; }

        public double? NominalOutput { get; init; }
        public decimal? NominalOutputPercentage { get; init; }
        public decimal? NonlinearityPercentage { get; init; }
        public int? MinimumDeadLoad { get; init; }
        public double? vMin { get; init; }
        public int? nMax { get; init; }
        public int? SafeLoad { get; init; }
        public int? UltimateLoad { get; init; }

        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string ShellMaterialName { get; init; } = string.Empty;
        public bool Alloy { get; init; }
        public int? DefaultCableLength { get; init; }
        public int? NumberOfGauges { get; init; }
        public int? Resistance { get; init; }
        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string CCNumber { get; init; } = string.Empty;
        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string AccuracyClass { get; init; } = string.Empty;
        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string Application { get; init; } = string.Empty;

        public int? TemperingHardnessLow { get; init; }
        public int? TemperingHardnessHigh { get; init; }

        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string NTEPCertificationId { get; init; } = string.Empty;
        public DateTime? NTEPCertificationTimestamp { get; init; }
        [BaseModelBasicAttribute(32, 0, false, false, false)]
        public string OIMLCertificationId { get; init; } = string.Empty;
        public DateTime? OIMLCertificationTimestamp { get; init; }
        public bool TestPointDirection { get; init; } = true;// true = increasing, false = decreasing

        // public ModelVersion ModelVersion { get; init; }
        public required ShellMaterial ShellMaterial { get; init; }
        public ICollection<TestPoint> TestPoints { get; set; } = new List<TestPoint>();



    }
}
