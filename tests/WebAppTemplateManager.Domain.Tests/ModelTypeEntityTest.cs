using WebAppTemplateManager.Domain.Entities;
using FluentAssertions;
using LanguageExt.Common;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Text.RegularExpressions;

namespace WebAppTemplateManager.Domain.Tests
{
    public class ModelTypeEntityTest
    {
        //[Fact]
        //public void CreateModelTypeShouldThrowAnExceptionWhenGuidValuesIsEmpty()
        //{
        //    //Arrange
        //    //Expected exception message to match the equivalent of "ModelType Guid cannot be empty guidId)", but "Model Type Guid cannot be empty guidId" does not.
        //    //Expected exception message to match the equivalent of "ModelType Guid Value cannot be empty guidId", but "Value cannot be null. (Parameter 'modelTypeName')" does not.

        //    var modelTypeName = "ML101";
        //    var nodelGrade = "SCALES/PAD";
        //    var guidId = Guid.Empty;
        //    var PropertyName = "ModelType Guid value cannot be empty guidId";
        //    //Act
        //    Action act = () => ModelType.Create(modelTypeName, nodelGrade, guidId);

        //    //Assert
        //    act.Should().Throw<ArgumentException>().WithMessage($"*{PropertyName}*");
        //}

        //[Fact(Skip = "I have check for other null @ Create")]
        //public void CreateModelTypeShouldThrowAnExceptionWhenModelTypeNameValuesIsNullOrEmpty()
        //{
        //    //Arrange
        //    //  Expected exception message to match the equivalent of "ModelType Guid Value cannot be empty guidId", but "Value cannot be null. (Parameter 'modelTypeName')" does not.

        //    var modelTypeName = "";
        //    var guidId = Guid.NewGuid();
        //    //Act
        //    Action act = () => ModelType.Create(null, null, guidId);
        //    //Assert
        //    act.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'modelTypeName')");
        //}
    }
}