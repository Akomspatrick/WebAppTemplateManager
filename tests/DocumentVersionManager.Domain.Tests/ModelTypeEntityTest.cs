using DocumentVersionManager.Domain.Entities;
using FluentAssertions;
using LanguageExt.Common;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Text.RegularExpressions;

namespace DocumentVersionManager.Domain.Tests
{
    public class ModelTypeEntityTest
    {
        [Fact]
        public void CreateModelTypeShouldThrowAnExceptionWhenGuidValuesIsEmpty()
        {
            //Arrange
            //Expected exception message to match the equivalent of "ModelType Guid cannot be empty guidId)", but "Model Type Guid cannot be empty guidId" does not.
            //Expected exception message to match the equivalent of "ModelType Guid Value cannot be empty guidId", but "Value cannot be null. (Parameter 'modelTypeName')" does not.

            var modelTypeName = "ML101";
            var guidId = Guid.Empty;
            //Act
            Action act = () => ModelType.Create(modelTypeName, guidId);
            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("ModelType Guid Value cannot be empty guidId");
        }

        [Fact]
        public void CreateModelTypeShouldThrowAnExceptionWhenModelTypeNameValuesIsNullOrEmpty()
        {
            //Arrange
            //  Expected exception message to match the equivalent of "ModelType Guid Value cannot be empty guidId", but "Value cannot be null. (Parameter 'modelTypeName')" does not.

            var modelTypeName = "";
            var guidId = Guid.Empty;
            //Act
            Action act = () => ModelType.Create(null, guidId);
            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'modelTypeName')");
        }
    }
}