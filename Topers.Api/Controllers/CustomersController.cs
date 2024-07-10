namespace Topers.Api.Contollers;

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;
using Topers.Core.Validators;

[ApiController]
[Route("api/customers")]
public class CustomersController(ICustomersService customerService) : ControllerBase
{
    private readonly ICustomersService _customerService = customerService;

    [HttpGet]
    [SwaggerResponse(200, Description = "Returns a customer list.", Type = typeof(IEnumerable<CustomerResponseDto>))]
    [SwaggerResponse(400)]
    public async Task<ActionResult<List<CustomerResponseDto>>> GetCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();

        if (customers == null)
        {
            return BadRequest();
        }

        return Ok(customers);
    }

    [HttpGet("{customerId:guid}")]
    [SwaggerResponse(200, Description = "Returns a customer.", Type = typeof(CustomerResponseDto))]
    [SwaggerResponse(400)]
    public async Task<ActionResult<CustomerResponseDto>> GetCustomerById([FromRoute] Guid customerId)
    {
        var customer = await _customerService.GetCustomerByIdAsync(customerId);

        if (customer == null)
        {
            return BadRequest();
        }

        return Ok(customer);
    }

    [HttpPost("create")]
    [SwaggerResponse(200, Description = "Create a new customer.")]
    public async Task<ActionResult<Guid>> CreateCustomer([FromBody] CustomerRequestDto customer)
    {
        var newCustomerValidator = new CustomerDtoValidator();
        
        var newCustomerValidatorResult = newCustomerValidator.Validate(customer);

        if (!newCustomerValidatorResult.IsValid)
        {
            return BadRequest(newCustomerValidatorResult.Errors);
        }

        var newCustomer = new Customer
        (
            Guid.Empty,
            null,
            customer.Name,
            customer.Email,
            customer.Phone
        );

        var newCustomerEntity = await _customerService.CreateCustomerAsync(newCustomer);

        return Ok(newCustomerEntity);
    }
}
