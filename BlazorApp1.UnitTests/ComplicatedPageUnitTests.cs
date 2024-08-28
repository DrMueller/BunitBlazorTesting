using BlazorApp1.Components;
using Bunit;
using Moq;
using Xunit;

namespace BlazorApp1.UnitTests;

public class ComplicatedPageUnitTests : TestContext
{
    [Fact]
    public void Test_MockInterface()
    {
        // Explanation: This doesn't work, mock is never used

        // Arrange
        var complicatedSelectMock = new Mock<IComplicatedSelect>();
        complicatedSelectMock
            .Setup(f => f.InitializeFirstSelectionAsync(It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        ComponentFactories.Add(complicatedSelectMock.Object);

        // Act
        RenderComponent<ComplicatedPage>();

        // Assert
        // Check the communication between ComplicatedPage and ComplicatedSelect
        complicatedSelectMock
            .Verify(f => f.InitializeFirstSelectionAsync(It.IsAny<int>()), Times.Once);
    }

    [Fact()]
    public void Test_MockClass()
    {
        // Explanation: This doesn't work, as the implementation doesn't define its member as virtual -> Which we wouldn't like to do just for testing purposes

        // Arrange
        var complicatedSelectMock = new Mock<ComplicatedSelect>();
        complicatedSelectMock
            .Setup(f => f.InitializeFirstSelectionAsync(It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        ComponentFactories.Add(complicatedSelectMock.Object);

        // Act
        RenderComponent<ComplicatedPage>();

        // Assert
        // Check the communication between ComplicatedPage and ComplicatedSelect
        complicatedSelectMock
            .Verify(f => f.InitializeFirstSelectionAsync(It.IsAny<int>()), Times.Once);
    }

    [Fact()]
    public void Test_MockAll()
    {
        // Explanation: This doesn't work, is I receive the error "System.InvalidCastException : Unable to cast object of type 'Bunit.TestDoubles.Stub`1[BlazorApp1.Components.ComplicatedSelect]' to type 'BlazorApp1.Components.ComplicatedSelect'."

        // Arrange
        ComponentFactories.AddStub(type => type != typeof(ComplicatedPage));

        // Act
        RenderComponent<ComplicatedPage>();

        // Assert
        // Check the communication between ComplicatedPage and ComplicatedSelect
    }
}