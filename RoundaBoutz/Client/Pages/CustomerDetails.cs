using Microsoft.AspNetCore.Components;
using RoundaBoutz.Client.Services;
using RoundaBoutz.Shared.Models;

namespace RoundaBoutz.Client.Pages;

public partial class CustomerDetails 
{
    protected string Message = string.Empty;
    protected Customer customer = new Customer();
    [Parameter]
    public Guid Id {get;set;}

    [Inject]
    private ICustomerService customerService {get; set;}

    [Inject]
    private NavigationManager navigationManager {get; set;}

}