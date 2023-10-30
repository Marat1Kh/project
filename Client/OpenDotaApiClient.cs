using System;
using System.Net.Http;
using System.Threading.Tasks;
public class OpenDotaApiClient{
    private readonly HttpClient httpClient;
    private const string BaseUrl = "https://api.opendota.com/api";
    public OpenDotaApiClient(){
        httpClient = new HttpClient();
    }
    public async Task<string> GetMatchInfoAsync(long matchId){
        try{
            string apiUrl = $"{BaseUrl}/matches/{matchId}";
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            if(response.IsSuccessStatuscode){
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else{
                Console.WriteLine($"Failed to retrieve match info");
                return null;
            }
        }
        catch (Exception ex){
            Console.WriteLine($"An error occurred");
            return null;
        }
    }
}