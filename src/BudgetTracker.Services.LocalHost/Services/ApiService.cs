using BudgetTracker.Core.Models;
using BudgetTracker.Services.LocalHost.Interfaces;
using System.Net.Http.Json;

namespace BudgetTracker.Services.LocalHost.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<Transaction>> GetTransactionsAsync()
    {
        var response = _httpClient.GetFromJsonAsync<IEnumerable<Transaction>>("api/transactions");
        if (response != null)
        {
            return response;
        }
        else { 
            throw new Exception("Failed to get transactions");
        }
    }
}
