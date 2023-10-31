using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class Revision
    {
        public DateTime Timestamp { get; init; }
        public string DocumentName { get; init; } = string.Empty;//documents_name
        public string ModelName { get; init; } = string.Empty;//documents_models_name
        public int RevisionNumber { get; init; }
        public string DocumentContentPath { get; init; } = string.Empty;//contentPDF
        public string ChangeOrderDocumentPath { get; init; } = string.Empty;

        public string Username { get; init; } = string.Empty;




    }
}
