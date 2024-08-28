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

        // That would be nice kindahow
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

        // That would be nice kindahow
        ComponentFactories.Add(complicatedSelectMock.Object);

        // Act
        RenderComponent<ComplicatedPage>();

        // Assert
        // Check the communication between ComplicatedPage and ComplicatedSelect
        complicatedSelectMock
            .Verify(f => f.InitializeFirstSelectionAsync(It.IsAny<int>()), Times.Once);
    }
}