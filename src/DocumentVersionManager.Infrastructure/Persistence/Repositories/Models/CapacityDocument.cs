using DocumentVersionManager.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories.Models
{

    public class CapacityDocument
    {
        public string ModelName { get; init; }
        public int Capacity { get; init; }
        public string DocumentPath { get; init; }
    }
}