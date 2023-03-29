using employeeProject.data;
using employeeProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace employeeProject.Controllers
{
    [Route("requests/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        public readonly MainDbContext _context;
        public RequestsController(MainDbContext context) => _context = context;

        // Creating new request 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePeople(Requests request)
        {   //Returns 204NoContent error when a user already exits with same email
            // var user_already_exists = GetUserByEmailId(people.Email);
            // if (user_already_exists != null) return BadRequest();
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRequestById), new { id = request.Id, status = false }, request);
        }

        //HttpGet people by Type
        [HttpGet("requestsRaisedBy/{byId:int}")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(People), StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<Requests>> GetRequestsRaisedBy(int byId)
        {// method is for displaying all People
         // If type is "admin" all admin and If type is "user"
         // type = type.ToLower();

            //if (type == null || type != "admin" && type != "users") return null;

            //bool role = type != "admin";

            //var user = await _context.People.FindAsync(role);

            var requests = _context.Requests.Where(r => r.Raised_By == byId).ToList();

            return requests;
        }
        //HttpGet people by Type
        [HttpGet("requests/{raised_to}")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(People), StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<Requests>> GetRequestsRaisedTo(string raised_to)
        {// method is for displaying all People
         // If type is "admin" all admin and If type is "user"
         // type = type.ToLower();

            //if (type == null || type != "admin" && type != "users") return null;

            //bool role = type != "admin";

            //var user = await _context.People.FindAsync(role);

            var requests = _context.Requests.Where(r => r.Raised_By_Name == raised_to).ToList();

            return requests;
        }


        [HttpGet] 
        //Get All requests
        public async Task<IEnumerable<Requests>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        [HttpGet("/{id:int}")]
        [ProducesResponseType(typeof(Requests), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Requests), StatusCodes.Status404NotFound)]
        // Get request by {id}
        public async Task<IActionResult> GetRequestById(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            return request == null ? NotFound() : Ok(request);
        }

        [HttpGet("status/{status}")]
        [ProducesResponseType(typeof(Requests), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Requests), StatusCodes.Status404NotFound)]
        // Status of a request Approved or rejected
        public async Task<IEnumerable<Requests>> GetRequestByStatus(string status)
        {

            // var request = await _context.Requests.FindAsync(status);
            //return request == null ? NotFound() : Ok(request);

            bool stat = status == "approved";

            //var user = await _context.People.FindAsync(role);

            var request = _context.Requests.Where(s => s.Request_Status == stat).ToList();
            return request;
        }

        //Update People info 
        [HttpPut]
        public IActionResult UpdateInfo(Requests request)
        {
            if (!ModelState.IsValid) return BadRequest("Not a Valid Credentials");
            var existingInfo = _context.Requests.Where(r => r.Id == request.Id).FirstOrDefault<Requests>();
            if (existingInfo == null) return NotFound();
            existingInfo.Request_Name = request.Request_Name;
            existingInfo.Request_Comment = request.Request_Comment;
            existingInfo.Request_Message = request.Request_Message;
            existingInfo.Request_Status = request.Request_Status;
            _context.SaveChanges();
            return Ok("Information Updated");
        }


        //Update People info 
        [HttpPut("/comment")]
        public IActionResult AddComment(Requests request)
        {
            if (!ModelState.IsValid) return BadRequest("Not a Valid Credentials");
            var existingInfo = _context.Requests.Where(r => r.Id == request.Id).FirstOrDefault<Requests>();
            if (existingInfo == null) return NotFound();
            existingInfo.Request_Comment = request.Request_Comment;
            _context.SaveChanges();
            return Ok("Information Updated");
        }

    }
}
