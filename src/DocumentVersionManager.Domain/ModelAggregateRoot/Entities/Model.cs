using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class Model
    {
        //name`,`modelTypes_name`
        public string ModelId { get; init; } = string.Empty;
        public string ModelName { get; init; } = string.Empty;
    }

}
