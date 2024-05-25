using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_LifeTime_SingletonScopedTransient.BAL;
using Service_LifeTime_SingletonScopedTransient.IBAL;
using Service_LifeTime_SingletonScopedTransient.Models;

namespace Service_LifeTime_SingletonScopedTransient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamsController : ControllerBase
    {
        public readonly IIceCreamsBAL _iceCreamsBAL;

        public IceCreamsController(IIceCreamsBAL iceCreamBAL) 
        {
            _iceCreamsBAL = iceCreamBAL;
        }

        [HttpPost]
        public IActionResult PostIceCream(IceCream iceCream)
        {
            bool res = _iceCreamsBAL.PostIceCreams(iceCream);
            if (res)
            {
                List<IceCream> icecreams = _iceCreamsBAL.GetIceCreams();
                return Ok(icecreams);
            }
            return BadRequest("Cannot post the data");

        }

        [HttpGet]
        public IActionResult GetIceCreams()
        {
            List<IceCream> icecreams = _iceCreamsBAL.GetIceCreams();
            return Ok(icecreams);
        }

    }
}
