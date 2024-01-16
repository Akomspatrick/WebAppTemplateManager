using CodeGeneratorAttributesLibrary;

namespace DocumentVersionManager.BaseModels.Entities
{
    [BaseModelsForeignKeyAttribute("ModelVersion", "TestPoints")]
    public class TestPoint : BaseEntity
    {
        [BaseModelBasicAttribute(32, 0, true, true, false)]
        public string ModelName { get; init; } = string.Empty;

        [BaseModelBasicAttribute(true, true)]
        public int ModelVersionId { get; init; }

        [BaseModelBasicAttribute(true)]
        public int CapacityTestPoint { get; init; }// these are the test points/weights for the capacity test
                                                   // we dont need to specify capacity again because the Modelversion already has it

        public ModelVersion ModelVersion { get; set; }

    }
}
