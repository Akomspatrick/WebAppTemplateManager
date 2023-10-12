using System.Reflection.Metadata;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public partial class Model
    {
        //if I am not using domain driven design then i can specify the detail model here eg 
        // public ModelType ModelType { get; set; }
        public string ModelId { get; init; } = string.Empty;
        public string ModelName { get; init; } = string.Empty;
        public string ModelTypeId { get; init; } = string.Empty;
        //if I am not using domain driven design then i can specify the detail model here eg 
        // public ModelType ModelType { get; set; }
        // Meaning that ModelTypename may evetualy become ModelTypeId
        private List<Document> _documents = Enumerable.Empty<Document>().ToList();
        private  List<CapacityDocument> _capacityDocuments = Enumerable.Empty<CapacityDocument>().ToList();
        private  List<CapacitySpecification> _capacitySpecifications = Enumerable.Empty<CapacitySpecification>().ToList();


        public IReadOnlyCollection<Document> Documents => _documents.AsReadOnly();
        public IReadOnlyCollection<CapacityDocument> CapacityDocumentsv => _capacityDocuments.AsReadOnly();
        public IReadOnlyCollection<CapacitySpecification> CapacitySpecificationsv => _capacitySpecifications.AsReadOnly();

        private delegate void ModelDataUpdatedEventHandler(Dictionary<string, List<int>> models);



        private static ModelDataUpdatedEventHandler DataUpdated;

        private static object pollingLock = new object();
        private static bool polling = false;


    }

}


