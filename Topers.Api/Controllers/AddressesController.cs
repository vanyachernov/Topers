using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;
using Topers.Core.Validators;

namespace Topers.Api.Controllers;

[ApiController]
[Route("api/addresses")]
public class AddressesController(IAddressesService addressesService) : ControllerBase
{
    private readonly IAddressesService _addressService = addressesService;

    [HttpPost("{customerId:guid}")]
    [SwaggerResponse(200, Description = "Returns the new address data of the customer.", Type = typeof(AddressResponseDto))]
    [SwaggerResponse(400, Description = "There are some errors in the model.")]
    public async Task<ActionResult<AddressResponseDto>> AddAddressToCustomer(
        [FromRoute] Guid customerId, 
        [FromBody] AddressRequestDto address,
        CancellationToken cancellationToken)
    {
        var newAddressValidator = new AddressDtoValidator();
        
        var newAddressValidatorResult = newAddressValidator.Validate(address);

        if (!newAddressValidatorResult.IsValid)
        {
            return BadRequest(newAddressValidatorResult.Errors);
        }

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

        var addressEntity = await _addressService.AddAddressToCustomerAsync(newAddress, cancellationToken);

        return Ok(addressEntity);
    }
}