using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot
{
    public partial class Model
    {
        public Model(string modelId, string modelName)
        {
            modelId = modelId;
            modelName = modelName;
        }
    }
}
