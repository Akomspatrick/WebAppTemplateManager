using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class TestFlowType  : BaseEntity
    {
        private TestFlowType(){}
            public int TestingModeId    { get; init; } 
            public string TestingMode    { get; init; }  = string.Empty; 
            public string Description    { get; init; }  = string.Empty; 
            public Guid GuidId    { get; init; } 
        
        public static TestFlowType Create(int  testingModeId, string  testingMode, string  description, Guid  guidId)
        =>new()
        {
            TestingModeId = testingModeId ,
            TestingMode = testingMode ,
            Description = description ,
            GuidId = guidId ,
        };
    }
}