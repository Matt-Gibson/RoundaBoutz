using Microsoft.AspNetCore.Components;
using RoundaBoutz.Client.Services;
using RoundaBoutz.Shared.Models;

namespace RoundaBoutz.Client.Pages;

public partial class Customers
{
    [Inject]
    private ICustomerService customerService {get; set;}
    
    private IEnumerable<Customer> _customers {get; set;} = new List<Customer>();
    protected async override Task OnInitializedAsync()
    {
        var apiCustomers = await customerService.All();

        if(apiCustomers != null && apiCustomers.Any())
        {
            _customers = apiCustomers;
        }
    }
}