
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AspNetCoreDocker.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreDocker.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController: Controller
    {    
        private EFContext _context;

        public OrdersController(EFContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Get([FromQuery] int take = 10)
        {
            return Json(this._context.Orders.Take(take).ToList());
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            return Json(this._context.Orders.Include(o=> o.Items).FirstOrDefault(o => o.Id == id));
        }

        [HttpPost]
        public void Post([FromBody] Order order)
        {
            this._context.Orders.Add(order);
            this._context.SaveChanges();
        }
    }    
}