using AppPWA.Models;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace AppPWA.Services;
public class PostService(HttpClient httpClient, ILocalStorageService localStorage)
{

    public async Task<List<Post>> GetPostsAsync()
    {
        try
        {
            var posts = await httpClient.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");

            if (posts != null)
            {
                await localStorage.SetItemAsync("posts", posts);
            }
            else
            {
                posts = await localStorage.GetItemAsync<List<Post>>("posts");
            }


            return posts ?? new List<Post>();
        }
        catch (Exception)
        {

            return await localStorage.GetItemAsync<List<Post>>("posts");
        }
        
    }

}
