using DocumentVersionManager.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public partial class Model
    {
        public const string DEFAULT_DOCUMENT_PATH = "F:\\MASSLOAD\\DWG\\Load Cell - Standard\\";

        public string ModelName { get; init; } = string.Empty;
        public string ModelTypeName { get; init; } = string.Empty;

        private  List<Document> _documents = Enumerable.Empty<Document>().ToList();
        private  List<CapacityDocument> _capacityDocuments = Enumerable.Empty<CapacityDocument>().ToList();
        private  List<CapacitySpecification> _capacitySpecifications = Enumerable.Empty<CapacitySpecification>().ToList();


        public IReadOnlyCollection<Document> Documentsv => _documents.AsReadOnly();
        public IReadOnlyCollection<CapacityDocument> CapacityDocumentsv => _capacityDocuments.AsReadOnly();
        public IReadOnlyCollection<CapacitySpecification> CapacitySpecificationsv => _capacitySpecifications.AsReadOnly();

        private delegate void ModelDataUpdatedEventHandler(Dictionary<string, List<int>> models);
        private static ModelDataUpdatedEventHandler DataUpdated;

        private static object pollingLock = new object();
        private static bool polling = false;


    }

}


