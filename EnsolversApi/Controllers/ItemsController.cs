using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnsolversBL.Data;
using EnsolversBL.Models;
using EnsolversBL.Repositories;
using Microsoft.AspNetCore.Authorization;
using EnsolversBL.DTOs;
using Microsoft.AspNetCore.Cors;

namespace EnsolversApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<Item> _repo;

        public ItemsController(IRepository<Item> repo)
        {
            _repo = repo;
        }

        // GET: api/Items
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            var tasks = await _repo.GetAll();
            return Ok(tasks);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Put(int id, ItemPutDTO itemPutDTO)
        {
            var itemToUpdate = await _repo.GetById(id);
            if(itemToUpdate == null)
            {
                return NotFound("task not found");
            }
            itemToUpdate.Data = itemPutDTO.Data;
            itemToUpdate.State = itemPutDTO.State;
            await _repo.Update(itemToUpdate);
            return Ok();
        }
        
        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repo.Delete(id);
            if(item != null)
                return Ok();
            return BadRequest();
        }

        // POST: api/Items
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Item>> Post(ItemPostDTO itemDTO)
        {
            Item item = new Item(itemDTO.Data);
            var task = await _repo.Add(item);
            return task;
        }

    }
}
