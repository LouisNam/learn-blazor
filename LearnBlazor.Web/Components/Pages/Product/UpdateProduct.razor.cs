using Blazored.Toast.Services;
using LearnBlazor.Model.Entities;
using LearnBlazor.Model.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace LearnBlazor.Web.Components.Pages.Product
{
    public partial class UpdateProduct : ComponentBase
    {
        [Parameter]
        public int ID { get; set; }

        [Inject]
        public ApiClient ApiClient { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ProductModel Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var res = await ApiClient.GetFormJsonAsync<BaseResponseModel>($"/api/Product/{ID}");
            if (res != null && res.Success)
            {
                Model = JsonConvert.DeserializeObject<ProductModel>(res.Data.ToString());
            }
        }

        public async Task Submit()
        {
            var res = await ApiClient.PutAsync<BaseResponseModel, ProductModel>($"api/Product/{ID}", Model);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Create product successfully");
                NavigationManager.NavigateTo("/product");
            }
        }
    }
}