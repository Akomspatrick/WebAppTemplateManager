
namespace DocumentVersionManager.BaseModels.Entities
{

    public class CapacityDocument : BaseEntity
    {
        public string ModelName { get; init; }
        public int Capacity { get; init; }
        public string DocumentPath { get; init; }


        public CapacityDocument(string modelName, int capacity, string documentPath)
        {
            ModelName = modelName;
            Capacity = capacity;
            DocumentPath = documentPath;
        }



    }
}