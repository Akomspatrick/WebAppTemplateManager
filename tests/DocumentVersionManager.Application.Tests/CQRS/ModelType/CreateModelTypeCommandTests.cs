using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Handlers;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Tests.CQRS.ModelType
{
    public class CreateModelTypeCommandTests
    {
        private static readonly ModelTypeCreateDTO modelTypeCreateDTO = new("ML101");
        private static readonly CreateModelTypeCommand createModelTypeCommand = new(new ApplicationModelTypeCreateDTO(modelTypeCreateDTO));

        private readonly CreateModelTypeCommandHandler createModelTypeCommandHandler;

        private readonly IUnitOfWork _unitOfWorkMock;
        private readonly IAppLogger<CreateModelTypeCommandHandler> _loggerMock;

        public CreateModelTypeCommandTests()
        {
            _unitOfWorkMock = Substitute.For<IUnitOfWork>();
            _loggerMock = Substitute.For<IAppLogger<CreateModelTypeCommandHandler>>();
            createModelTypeCommandHandler = new CreateModelTypeCommandHandler(_unitOfWorkMock, _loggerMock);
        }

        [Fact]
        public async Task CreateModelTypeCommandHandler_ShouldReturnSuccess()
        {
            //Arrange
            _unitOfWorkMock.ModelTypeRepository.AddAsync(Arg.Any<Domain.Entities.ModelType>(), Arg.Any<CancellationToken>()).Returns(1);
            //Act
            var result = await createModelTypeCommandHandler.Handle(createModelTypeCommand, CancellationToken.None);
            //Assert
            //result.IsRigh.Should().BeEquivalentTo("Success");
            result.IsRight.Should().BeTrue();
            result.Match(
             Right: r => r.Should().Be(1),
             Left: l => l.Should().Be(Arg.Any<GeneralFailure>()));//INTERESTED ONLY IN RIGHT SIDE
        }

        [Fact]
        public async Task CreateModelTypeCommandHandler_ShouldReturnFailure()
        {
            //Arrange
            _unitOfWorkMock.ModelTypeRepository.AddAsync(Arg.Any<Domain.Entities.ModelType>(), Arg.Any<CancellationToken>()).Returns(GeneralFailures.ProblemAddingEntityIntoDbContext("2a7c336a-163c-487d-88ca-c41cc129f118"));
            //Act
            var result = await createModelTypeCommandHandler.Handle(createModelTypeCommand, CancellationToken.None);
            //Assert
            result.IsLeft.Should().BeTrue();
            result.Match(
                         Right: r => r.Should().Be(Arg.Any<int>()),
                         Left: l => l.Should().BeEquivalentTo(GeneralFailures.ProblemAddingEntityIntoDbContext("2a7c336a-163c-487d-88ca-c41cc129f118")));//INTERESTED ONLY IN LEFT SIDE

        }
        [Fact]
        public async Task CreateModelTypeCommandHandler_ShouldReturnException()
        {
            //Arrange
            //  _unitOfWorkMock.ModelTypesRepository.AddAsync(Arg.Any<Domain.Entities.ModelTypes>(), Arg.Any<CancellationToken>()).Returns(GeneralFailure.ProblemAddingEntityIntoDbContext);
            //Act
            var _ = await createModelTypeCommandHandler.Handle(createModelTypeCommand, CancellationToken.None);
            //Assert
            _loggerMock.Received(1).LogInformation(Arg.Any<string>());
        }
        [Fact]
        public async Task CreateModelTypeCommandHandler_ShouldReturnException1()
        {
            //Arrange

            //Act
            var _ = await createModelTypeCommandHandler.Handle(createModelTypeCommand, CancellationToken.None);
            //Assert
            await _unitOfWorkMock.Received(1).ModelTypeRepository.AddAsync(Arg.Any<Domain.Entities.ModelType>(), Arg.Any<CancellationToken>());

        }
    }
}
