using Microsoft.AspNetCore.Mvc;
using OrdersService.Models;

namespace OrdersService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
    private static List<Order> items = new();
    private static int id=0;
    [HttpGet] public IEnumerable<Order> GetAll()=>items;

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            //     var order = items.FirstOrDefault(x => (int)x.GetType().GetProperty("Id")!.GetValue(x)! == id);

            // if (order == null)
            // {
            //     return NotFound();
            // }

            // return order;

            var order = items.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
    }

    [HttpPost] public ActionResult<Order> Create(Order dto) { dto.GetType().GetProperty("Id")!.SetValue(dto, ++id); items.Add(dto); return CreatedAtAction(nameof(Get), new { id }, dto); }
    }
}