
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AspNetCoreDocker.Models;

namespace AspNetCoreDocker.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController: Controller
    {    
        private EFContext _context;

        public OrdersController(EFContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public List<Order> Get([FromQuery] int take = 10)
        {
            return this._context.Orders.Take(take).ToList();
        }

        [HttpGet("{id:Guid}")]
        public Order GetById(Guid id)
        {
            return this._context.Orders.Include(o=> o.Items).FirstOrDefault(o => o.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Order order)
        {
            this._context.Orders.Add(order);
            this._context.SaveChanges();
        }
    }    
}