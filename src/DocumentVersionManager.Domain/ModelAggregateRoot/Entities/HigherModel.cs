using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class HigherModel : BaseEntity<string>
    {
        public string HigherModelName { get; private set; } = string.Empty;
        public string HigherModelDescription { get; private set; } = string.Empty;
        public string ProductId { get; private set; } = string.Empty;
        public int Capacity { get; private set; } = 0;


        public static HigherModel Create(string higherModelName, string productId, string higherModelDescription, int capacity)
        {
            if (string.IsNullOrWhiteSpace(higherModelName))
            {
                throw new ArgumentNullException(nameof(higherModelName));

            }
            if (higherModelName.Length > FixedValues.modelTypesNameMaxLength)
            {
                throw new ArgumentException($"HigherModelName cannot be more than {FixedValues.modelTypesNameMaxLength} characters {nameof(higherModelName)} ");
            }

            if (higherModelName.Length < FixedValues.modelTypesNameMinLength)
            {
                throw new ArgumentException($"HigherModelName cannot be less than {FixedValues.modelTypesNameMinLength} characters {nameof(higherModelName)} ");
            }


            return new HigherModel()
            {
                HigherModelName = higherModelName,
                Id = Guid.NewGuid().ToString(),
                HigherModelDescription = higherModelDescription,
                ProductId = productId,
                Capacity = capacity

            };
            // do some heavy lifting.
        }
    }
}
