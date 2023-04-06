using Microsoft.AspNetCore.Components;
using RoundaBoutz.Client.Services;
using RoundaBoutz.Shared.Models;

namespace RoundaBoutz.Client.Pages;

public partial class CustomerDetails 
{
    protected string Message = string.Empty;
    protected Customer customer {get;set;} = new Customer();
    [Parameter]
    public Guid Id {get;set;}

    [Inject]
    private ICustomerService customerService {get; set;}

    [Inject]
    private NavigationManager navigationManager {get; set;}

    protected async override Task OnInitializedAsync()
    {
        if(Id == Guid.Empty)
        {
            // Add new Customer
        }

        else
        {
            //Update existing Customer
            var apiCustomer = await customerService.GetCustomer(Id);

            if(apiCustomer != null)
            {
                customer = apiCustomer;
            }
        }
    }

    protected void HandleFailedRequest()
    {
        Message = "An error occured, please check your entries and try again.";
    }

    protected void GoToCustomers()
    {
        navigationManager.NavigateTo("/Customers");
    }

}