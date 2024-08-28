using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components
{
    public interface IComplicatedSelect : IComponent
    {
        Task InitializeFirstSelectionAsync(int index);
    }
}
