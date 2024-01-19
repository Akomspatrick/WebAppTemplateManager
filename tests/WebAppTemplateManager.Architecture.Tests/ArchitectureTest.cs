using NetArchTest.Rules;
using FluentAssertions;
namespace WebAppTemplateManager.Architecture.Tests
{
    public class ArchitectureTest
    {
        public class ArchitectuteTest
        {
            //private const string _solutionPath = @"..\..\..\..\..\";
            //private const string _projectName = "ProductionManager";
            //private const string _projectPath = _solutionPath + _projectName;
            //private const string _testProjectName = _projectName + ".ArchitectureTests";
            private const string DomainNamesspace = "WebAppTemplateManager.Domain";
            private const string InfrastructureNamespace = "WebAppTemplateManager.Infrastructure";
            private const string ApplicationNamespace = "WebAppTemplateManager.Application";
            private const string Presentation = "WebAppTemplateManager.Api";
            private const string Contract = "WebAppTemplateManager.Contracts";
            private const string DomainBaseNamesspace = "WebAppTemplateManager.DomainBase";
            private const string BaseModels = "WebAppTemplateManager.BaseModels";



            [Fact]
            public void BaseDomainLayerShouldNotHaveReferenceToOtherLayersExceptBaseDomainNamesspace()
            {
                //Arrange
                var assembly = typeof(DomainBase.DomainBaseAssembleRefrenceMarker).Assembly;
                var otherLayers = new[] { DomainNamesspace, InfrastructureNamespace, ApplicationNamespace, Presentation, Contract, BaseModels };
                //BaseDomainNamesspace
                //Act
                var testResult = Types.InAssembly(assembly)
                     .ShouldNot()
                     .HaveDependencyOnAll(otherLayers)
                     .GetResult();
                //Assert
                testResult.IsSuccessful.Should().BeTrue();

            }

            [Fact]
            public void DomainLayerShouldNotHaveReferenceToOtherLayersExceptBaseDomainNamesspace()
            {
                //Arrange
                var assembly = typeof(Domain.DomainAssemblyReferenceMarker).Assembly;
                var otherLayers = new[] { InfrastructureNamespace, ApplicationNamespace, Presentation, Contract, BaseModels };
                //BaseDomainNamesspace
                //Act
                var testResult = Types.InAssembly(assembly)
                     .ShouldNot()
                     .HaveDependencyOnAll(otherLayers)
                     .GetResult();
                //Assert
                testResult.IsSuccessful.Should().BeTrue();

            }


            [Fact]
            public void ApplicationLayerShouldNotHaveReferenceToOtherLayers()
            {
                //Arrange
                var assembly = typeof(Application.ApplicationAssemblyReferenceMarker).Assembly;
                var otherLayers = new[] { InfrastructureNamespace, Presentation, Contract, BaseModels, DomainBaseNamesspace };
                //BaseDomainNamesspace
                //Act
                var testResult = Types.InAssembly(assembly)
                     .ShouldNot()
                     .HaveDependencyOnAll(otherLayers)
                     .GetResult();
                //Assert
                testResult.IsSuccessful.Should().BeTrue();

            }


            [Fact]
            public void InfrastructureLayerShouldNotHaveReferenceToOtherLayers()
            {
                //Arrange
                var assembly = typeof(Infrastructure.InfrastructureAssembleRefrenceMarker).Assembly;
                var otherLayers = new[] { Presentation, Contract, BaseModels, DomainBaseNamesspace };
                //BaseDomainNamesspace
                //Act
                var testResult = Types.InAssembly(assembly)
                     .ShouldNot()
                     .HaveDependencyOnAll(otherLayers)
                     .GetResult();
                //Assert
                testResult.IsSuccessful.Should().BeTrue();

            }
            [Fact]
            public void PresentationLayerShouldNotHaveReferenceToOtherLayers()
            {
                //Arrange
                var assembly = typeof(Api.APIAssemblyRefrenceMarker).Assembly;
                var otherLayers = new[] { DomainNamesspace, Contract, BaseModels, DomainBaseNamesspace };
                //BaseDomainNamesspace
                //Act
                var testResult = Types.InAssembly(assembly)
                     .ShouldNot()
                     .HaveDependencyOnAll(otherLayers)
                     .GetResult();
                //Assert
                testResult.IsSuccessful.Should().BeTrue();

            }
            [Fact]
            public void DomainLayerShouldHaveReferenceToBaseDomainNamesspace()
            {
                //Arrange
                var assembly = typeof(Domain.DomainAssemblyReferenceMarker).Assembly;

                //Act
                var testResult = Types.InAssembly(assembly).That().Inherit(typeof(DomainBase.BaseEntity)).And().DoNotInherit(typeof(Domain.Entities.BaseEvent))
         //var testResult = Types.InAssembly(assembly).That().Inherit(typeof(DomainBase.BaseEntity)).And()..HaveNameEndingWith("Event")
         .Should()
         .HaveDependencyOn(DomainBaseNamesspace)
         .GetResult();


                //Assert
                testResult.IsSuccessful.Should().BeTrue();
            }
            [Fact]
            public void Handlers_ShouldHaveDependenciesOnDomain()
            {
                //Arrange
                var assembly = typeof(Application.ApplicationAssemblyReferenceMarker).Assembly;
                // var otherLayers = new[] { BaseModels };
                //BaseDomainNamesspace
                //Act
                var testResult = Types.InAssembly(assembly).That().HaveNameEndingWith("Handler")
                     .Should()
                     .HaveDependencyOn(DomainNamesspace)
                     .GetResult();
                //Assert
                testResult.IsSuccessful.Should().BeTrue();

            }
        }
    }
}