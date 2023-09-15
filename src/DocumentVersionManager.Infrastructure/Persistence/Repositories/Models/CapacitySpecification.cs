using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories.Models
{

    public class CapacitySpecification
    {


        public string ModelName  { get; init; } = string.Empty;
        public int Capacity  { get; init; } 
        public DateTime Timestamp  { get; init; }
        public string Username  { get; init; } = string.Empty;
        public double? NominalOutput  { get; init; } 
        public decimal? NominalOutputPercentage  { get; init; } 
        public decimal? NonlinearityPercentage  { get; init; } 
        public int? MinimumDeadLoad  { get; init; }
        public double? vMin  { get; init; } 
        public int? nMax  { get; init; } 
        public int? SafeLoad  { get; init; } 
        public int? UltimateLoad  { get; init; }
        public string ShellMaterial  { get; init; } = string.Empty;
        public bool Alloy  { get; init; } 
        public int? DefaultCableLength  { get; init; } 
        public int? TempRangeLow  { get; init; }
        public int? TempRangeHigh  { get; init; }
        public int? NumberOfGauges  { get; init; }
        public int? Resistance  { get; init; }
        public string CCNumber  { get; init; } = string.Empty;
        public string Class  { get; init; } = string.Empty;
        public string Application  { get; init; }
        public int? NumberInBasket  { get; init; } 
        public double? AustenitizationTemperatureInF  { get; init; } 
        public int? AustenitizationTimeInSeconds  { get; init; }
        public int? AustenitizationHardnessLow  { get; init; } 
        public int? AustenitizationHardnessHigh  { get; init; }
        public double? TemperingTemperatureInF  { get; init; }
        public int? TemperingTimeInSeconds  { get; init; }
        public int? TemperingHardnessLow  { get; init; } 
        public int? TemperingHardnessHigh  { get; init; } 
        public bool HasScrews  { get; init; }
        public string NTEPCertificationId  { get; init; } = string.Empty;
        public DateTime? NTEPCertificationTimestamp  { get; init; }
        public string OIMLCertificationId  { get; init; } = string.Empty;
        public DateTime? OIMLCertificationTimestamp  { get; init; }

        

    }
}