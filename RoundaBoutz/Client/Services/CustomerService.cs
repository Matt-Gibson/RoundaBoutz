using System.Text;
using System.Text.Json;
using RoundaBoutz.Shared.Models;

namespace RoundaBoutz.Client.Services;

public class CustomerService : ICustomerService
{

    private readonly HttpClient _httpClient;
    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Customer?> AddCustomer(Customer customer)
    {
        try
        {
            var customerJson = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/customers", customerJson);

            if(response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStreamAsync();
                var addedCustomer = await JsonSerializer.DeserializeAsync<Customer>(responseBody, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});

                return addedCustomer;
            }
            return null;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw ex;
        }
    }

    public async Task<IEnumerable<Customer>?> All()
    {
         try
        {
            var apiResponse = await _httpClient.GetStreamAsync("api/customers");

            var customers = await JsonSerializer.DeserializeAsync<IEnumerable<Customer>>(apiResponse, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});

            return customers;

        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw ex;
        }
    }

    public async Task<bool> Delete(Guid id)
    {
         try
        {
            var response = await _httpClient.DeleteAsync($"api/customers/{id}");
            
            if(response != null)
            return response.IsSuccessStatusCode;

            else
            {return false;}
        }
          catch(Exception ex)
        {
              Console.WriteLine($"Error: {ex.Message}");
              throw ex;
        }

    }

    public async Task<Customer?> GetCustomer(Guid id)
    {
         try
        {
            var response = await _httpClient.GetStreamAsync($"api/customers/{id}");
            var customer = await JsonSerializer.DeserializeAsync<Customer>(response, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});

            return customer;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw ex;
        }

    }

    public async Task<bool> Update(Customer customer)
    {
        try
        {
            var customerJson = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/customers/{customer.Id}", customerJson);

           return response.IsSuccessStatusCode;
        }
       
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw ex;
        }

    } 
}