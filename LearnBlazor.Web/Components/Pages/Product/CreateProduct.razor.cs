using Blazored.Toast.Services;
using LearnBlazor.Model.Entities;
using LearnBlazor.Model.Models;
using Microsoft.AspNetCore.Components;

namespace LearnBlazor.Web.Components.Pages.Product
{
    public partial class CreateProduct
    {
        [Inject]
        public ApiClient ApiClient { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ProductModel Model { get; set; }

        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<BaseResponseModel, ProductModel>("api/Product", Model);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Create product successfully");
                NavigationManager.NavigateTo("/product");
            }
        }
    }
}