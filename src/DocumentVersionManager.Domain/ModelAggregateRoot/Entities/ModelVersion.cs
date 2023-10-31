using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class ModelVersion:BaseEntity
    {   public int ModelVersionId { get; init; }
        
        public string VersionDescription { get; init; } = string.Empty;
        public string ModelVersionName { get; init; } = string.Empty;


        public Model Models;
        public string ModelName { get; init; } = string.Empty;
        public Guid ModelVersionGuid { get; init; }
   
        
        public DateTime Timestamp { get; init; }

        public string Username { get; init; } = string.Empty;


        public ICollection<Document> Documents;

        public static ModelVersion Create(Guid modelVersionGUID, string modelVersionName, int modelVersionId, string versionDescription, string modelName,string username, DateTime timestamp)
        {
            if ((modelVersionId < 0))
            {
                throw new ArgumentException($"modelVersionId cannot be more than be less that zero ");


            }

            if (string.IsNullOrWhiteSpace(modelName))
            {
                throw new ArgumentNullException(nameof(modelName));

            }
            if (modelName.Length > FixedValues.ModelNameMaxLength)
            {
                throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelNameMaxLength} characters {nameof(modelName)} ");
            }

            if (modelName.Length < FixedValues.ModelNameMinLength)
            {
                throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelNameMaxLength}  characters  {nameof(modelName)} ");
            }



            return new ModelVersion() {
            ModelVersionGuid = modelVersionGUID,
            ModelVersionName = modelVersionName,
            ModelVersionId = modelVersionId,
            VersionDescription = versionDescription,
            ModelName = modelName,
            Username = username,
            Timestamp = timestamp

            };

        }
    }
}
