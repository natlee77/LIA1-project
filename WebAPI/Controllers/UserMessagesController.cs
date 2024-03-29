﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly LIADbContext _context;

        public UserMessagesController(LIADbContext context)
        {
            _context = context;
        }

        // GET: api/UserMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMessage>>> GetUserMessages()
        {
            return await _context.UserMessages.ToListAsync();
        }

        // GET: api/UserMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMessage>> GetUserMessage(int id)
        {
            var userMessage = await _context.UserMessages.FindAsync(id);

            if (userMessage == null)
            {
                return NotFound();
            }

            return userMessage;
        }

        // PUT: api/UserMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMessage(int id, UserMessage userMessage)
        {
            if (id != userMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(userMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserMessage>> PostUserMessage(UserMessage userMessage)
        {
            _context.UserMessages.Add(userMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserMessage", new { id = userMessage.Id }, userMessage);
        }

        // DELETE: api/UserMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMessage(int id)
        {
            var userMessage = await _context.UserMessages.FindAsync(id);
            if (userMessage == null)
            {
                return NotFound();
            }

            _context.UserMessages.Remove(userMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserMessageExists(int id)
        {
            return _context.UserMessages.Any(e => e.Id == id);
        }
    }
}
