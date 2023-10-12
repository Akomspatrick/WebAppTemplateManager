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

        public static HigherModel Create(string higherModelName)
        {
            if (string.IsNullOrWhiteSpace(higherModelName))
            {
                throw new ArgumentNullException(nameof(higherModelName));

            }
            if (higherModelName.Length > FixedValues.ModelTypeNameMaxLength)
            {
                throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelTypeNameMaxLength} characters {nameof(higherModelName)} ");
            }

            if (higherModelName.Length < FixedValues.ModelTypeNameMinLength)
            {
                throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelTypeNameMinLength} characters {nameof(higherModelName)} ");
            }


            return new HigherModel() { HigherModelName  = higherModelName, Id = Guid.NewGuid().ToString() };
            // do some heavy lifting.
        }
    }
}
