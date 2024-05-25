using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_LifeTime_SingletonScopedTransient.Models;
using Service_LifeTime_SingletonScopedTransient.BAL;

namespace Service_LifeTime_SingletonScopedTransient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamController : ControllerBase
    {
        public readonly IceCreamBAL _iceCreamBAL;
        public IceCreamController() 
        {
            _iceCreamBAL = new IceCreamBAL();
        }

        [HttpPost]
        public IActionResult PostIceCream(IceCream iceCream)
        {
            bool res = _iceCreamBAL.PostIceCreams(iceCream);
            if (res)
            {
                List<IceCream> icecreams = _iceCreamBAL.GetIceCreams();
                return Ok(icecreams);
            }
            return BadRequest("Cannot post the data");

        }
        [HttpGet]
        public IActionResult GetIceCreams()
        {
            List<IceCream> icecreams = _iceCreamBAL.GetIceCreams();
            return Ok(icecreams);
        }
    }
}
