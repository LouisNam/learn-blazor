using Blazored.Toast.Services;
using LearnBlazor.Model.Entities;
using LearnBlazor.Model.Models;
using LearnBlazor.Web.Components.BaseComponents;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace LearnBlazor.Web.Components.Pages.Product
{
    public partial class IndexProduct
    {
        [Inject]
        public ApiClient ApiClient { get; set; }

        public List<ProductModel> ProductModels { get; set; }

        public AppModal Modal { get; set; }

        public int DeleteId { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadProduct();
        }

        protected async Task LoadProduct()
        {
            var res = await ApiClient.GetFormJsonAsync<BaseResponseModel>("api/Product");
            if (res != null && res.Success)
            {
                ProductModels = JsonConvert.DeserializeObject<List<ProductModel>>(res.Data.ToString());
            }
        }

        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"api/Product/{DeleteId}");
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Delete product successfully");
                await LoadProduct();
                Modal.Close();
            }
        }
    }
}