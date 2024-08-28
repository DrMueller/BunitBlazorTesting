


namespace BlazorApp1.Components
{
    public partial class ComplicatedPage
    {
        public required IComplicatedSelect SelectRef { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await SelectRef.InitializeFirstSelectionAsync(new Random().Next(10, 1000));
        }
    }
}
