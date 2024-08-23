using BookRateNetCore.Shared.Dtos;
using BookRateNetCore.Shared.Models;
using BookRateNetCore.Shared.Services;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;




namespace BookRateNetCore.Client.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient httpClient;

        public BookService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task <List<CategoryDto>> GetCategories()
        {
            var response = await httpClient.GetFromJsonAsync<ApiResponse<CategoryDto>>("api/Book/GetCategory");
            if (response is not null)
            {
                return response.Result;
            }
            return new List<CategoryDto>();
        }


        public async Task DeleteCategory(Guid id)
        {
            await httpClient.DeleteAsync($"api/Book/DeleteCategory/{id}");
        }


        public async Task UpdateCategory(CategoryDto category)
        {
            await httpClient.PutAsJsonAsync("api/Book/UpdateCategory", category);
        }

        public async Task AddCategory(CategoryDto category)
        {
            await httpClient.PostAsJsonAsync("api/Book/AddCategory", category);
        }


    }
}
