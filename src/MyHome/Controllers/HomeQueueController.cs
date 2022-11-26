using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MyHome.Domain.Aggregate;
using MyHome.Domain.Services;

namespace MyHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeQueueController : ControllerBase
    {
        private static HomeQueue _homeQueue;
        public HomeQueueController(IOrderStrategy orderStrategy)
        {
            if (_homeQueue == null)
            {
                _homeQueue = new(orderStrategy);
            }
        }

        [HttpPost]
        public ActionResult AddFamily([FromBody] Family family)
        {
            _homeQueue.AddFamily(family);

            return NoContent();
        }


        [HttpGet]
        public ActionResult GetAbleFamily()
        {
            return Ok(_homeQueue.GetAbleFamily());
        }

        [HttpGet]
        [Route("all")]
        public ActionResult GetAll()
        {
            return Ok(_homeQueue.Families);
        }

        [HttpDelete]
        public ActionResult CleanQueue()
        {
            _homeQueue.Families.Clear();
            return NoContent();
        }

        [HttpDelete]
        [Route("pop")]
        public ActionResult PopFamily()
        {
            _homeQueue.PopFamily();
            return NoContent();
        }
    }
}
