using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_LifeTime_SingletonScopedTransient.IBAL;
using Service_LifeTime_SingletonScopedTransient.Models;

namespace Service_LifeTime_SingletonScopedTransient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamssController : ControllerBase
    {
        public readonly IIceCreamssBAL _iceCreamsBAL;
        public readonly IIceCreamssBAL _iceCreamsBAL1;


        public IceCreamssController(IIceCreamssBAL iceCreamBAL, IIceCreamssBAL iceCreamBAL1)
        {
            _iceCreamsBAL = iceCreamBAL;
            _iceCreamsBAL1 = iceCreamBAL1;
        }

        [HttpPost]
        public IActionResult PostIceCream(IceCream iceCream)
        {
            bool res = _iceCreamsBAL.PostIceCreams(iceCream);
            if (res)
            {
                List<IceCream> icecreams = _iceCreamsBAL1.GetIceCreams();
                return Ok(icecreams);
            }
            return BadRequest("Cannot post the data");

        }

        [HttpGet]
        public IActionResult GetIceCreams()
        {
            List<IceCream> icecreams = _iceCreamsBAL1.GetIceCreams();
            return Ok(icecreams);
        }
    }
}
