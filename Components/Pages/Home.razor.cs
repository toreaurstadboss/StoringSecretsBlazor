using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace StoringSecrets.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public required IOptionsMonitor<ModelSecrets> ModelSecretsMonitor { get; set; }

        public ModelSecrets? ModelSecrets  { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ModelSecrets = ModelSecretsMonitor.CurrentValue;
            ModelSecretsMonitor.OnChange(updatedSecrets =>
            {
                ModelSecrets = updatedSecrets;
                InvokeAsync(StateHasChanged);

            });
            await Task.CompletedTask;
        }


    }
}
