using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Api.Controllers;

[ApiController]
[Route("api/addresses")]
public class AddressesController(IAddressesService addressesService) : ControllerBase
{
    private readonly IAddressesService _addressService = addressesService;

    [HttpPost("{customerId:guid}")]
    [SwaggerResponse(200, Description = "Returns the new address data of the customer.", Type = typeof(AddressResponseDto))]
    public async Task<ActionResult<AddressResponseDto>> AddAddressToCustomer([FromRoute] Guid customerId, [FromBody] AddressRequestDto address)
    {
        var newAddress = new Address
        (
            Guid.Empty,
            customerId,
            address.Street,
            address.City,
            address.State,
            address.PostalCode,
            address.Country
        );

        var addressEntity = await _addressService.AddAddressToCustomerAsync(newAddress);

        return Ok(addressEntity);
    }
}