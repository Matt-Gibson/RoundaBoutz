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

    protected async Task DeleteCustomer()
    {
        if(Id != Guid.Empty)
        {
            var result = await customerService.Delete(Id);

            if(result)
            {
                navigationManager.NavigateTo("/Customers");
            }
            else
            {
                Message = "An error occured, Customer was not deleted.";
            }
        }
    }

    protected async void HandleValidRequest()
    {
        if(Id == Guid.Empty)
        {
            var result = await customerService.AddCustomer(customer);

            if(result == null)
            {
                Message = "An Error Occured, Customer not added.";
            }

            navigationManager.NavigateTo("/Customers");
        }
        else
        {
            var result = await customerService.Update(customer);

            if(result)
            {
                navigationManager.NavigateTo("/Customers");
            }
            else
            {
                Message = "An Error Occured, Customer not Updated.";
            }
        }
    }

}