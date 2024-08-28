namespace BlazorApp1.Components
{
    public partial class ComplicatedSelect : IComplicatedSelect
    {
        private int Index { get; set; }

        public Task InitializeFirstSelectionAsync(int index)
        {
            Index = index;
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
