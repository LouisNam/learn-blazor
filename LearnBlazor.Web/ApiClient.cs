using Newtonsoft.Json;

namespace LearnBlazor.Web;

public class ApiClient(HttpClient httpClient)
{
    public Task<T> GetFormJsonAsync<T>(string path)
    {
        return httpClient.GetFromJsonAsync<T>(path);
    }

    public async Task<T1> PostAsync<T1, T2>(string path, T2 postModel)
    {
        var res = await httpClient.PostAsJsonAsync(path, postModel);
        if (res != null && res.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
        }
        return default;
    }
}