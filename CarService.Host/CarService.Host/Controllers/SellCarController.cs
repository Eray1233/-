using CarService.BL.Interfaces;
using CarService.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Host.Controllers;

[ApiController]
[Route("api/sell")]
public class SellCarController : ControllerBase
{
    private readonly ISellCar _sellCarService;

    public SellCarController(ISellCar sellCarService)
    {
        _sellCarService = sellCarService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(SellCarResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Sell(Guid carId, Guid customerId)
    {
        var result = _sellCarService.Sell(carId, customerId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
