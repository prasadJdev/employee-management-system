using employeeProject.data;
using employeeProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace employeeProject.Controllers
{
    [Route("login/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly MainDbContext _context;
        public PeopleController(MainDbContext context) => _context = context;

        // Creating new User || Admin 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePeople(People people)
        {   //Returns 204NoContent error when a user already exits with same email
            // var user_already_exists =  GetUserByEmailId(people.Email);
            //if (user_already_exists != null) return BadRequest(user_already_exists);
            var user = _context.People.Where(p => p.Email == people.Email).FirstOrDefault();
            if (user != null) return BadRequest("User already Exists ");
            var userName = _context.People.Where(p => p.Name == people.Name).FirstOrDefault();
            if (userName != null) return BadRequest("User Name already Exists ");

            await _context.People.AddAsync(people);
            await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetUserById), new { id = people.Id }, people);
            return Ok("Account created success");

        }


        //HttpGet people by Type
        [HttpGet("people/{type}")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(People), StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<People>> GetPeople(string type)
        {// method is for displaying all People
         // If type is "admin" all admin and If type is "user"
            type = type.ToLower();

            if (type == null || type != "admin" && type != "users") return null;

            bool role = type != "admin";

            //var user = await _context.People.FindAsync(role);

            var users = _context.People.Where(s => s.Role == role).ToList();

            return users;
        }

        /*HttpGet with id for Login */
        [HttpGet("verify/{email}/{password}/{dateTme}")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(People), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(People), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerifyUser(string email, string password, string dateTme)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid Email");
            }
            var user = _context.People.Where(s => s.Email == email).FirstOrDefault();
            if (user?.Password != password) { return Unauthorized("Password Doesn't match"); }


            //var existingInfo = _context.People.Where(p => p.Email == email).FirstOrDefault<People>();
            //var existingInfo = GetUserByEmailId(email);
            //if (existingInfo == null) return NotFound();
            //existingInfo.Name = people.Name;
            //existingInfo.Email = people.Email;
            user.LastActive = dateTme;
           // existingInfo.Forgot_Password= forgotPassword;
            _context.SaveChanges();



            return Ok(user);

            //var user = await _context.People.FindAsync(email);

            //return user == null ? NotFound() : Ok(user);
        }


        /* Send OTP /
        [HttpGet("code/{email}")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(People), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(People), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerifyCode(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid Email");
            }
            var user = _context.People.Where(s => s.Email == email).FirstOrDefault();
            if (user == null) return BadRequest("Invalid Email");



            //if (user?.Forgot_Password != code) { return Unauthorized("Password Doesn't match"); }

            return Ok(user);

            //var user = await _context.People.FindAsync(email);

            //return user == null ? NotFound() : Ok(user);
        }
        */


        /*HttpGet with id */
        [HttpGet("code/verify/{email}/{code}")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(People), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(People), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerifyCode(string email, string code)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid Email");
            }
            var user = _context.People.Where(s => s.Email == email).FirstOrDefault();
            if (user == null) return NotFound("Email doesnt exists Consider Sign-Up");
            if (user?.Forgot_Password != code) { return Unauthorized("Password Doesn't match"); }

            return Ok(user);

            //var user = await _context.People.FindAsync(email);

            //return user == null ? NotFound() : Ok(user);
        }


        /*HttpGet with id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(People), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.People.FindAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        //HttpGet with email
        [HttpGet("email/{email}")]
        [ProducesResponseType(typeof(People), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(People), StatusCodes.Status404NotFound)]
        public People GetUserByEmailId(string email)
        {
            var user = _context.People.Where(p => p.Email == email).FirstOrDefault();
            return user;
        }
        */
        //Update People info 
        [HttpPut("update/{email}/{password}/{forgotPassword}")]
        public IActionResult UpdateInfo(string email, string password, string forgotPassword)
        {
            if (!ModelState.IsValid) return BadRequest("Not valid Credentials");

            var existingInfo = _context.People.Where(p => p.Email == email).FirstOrDefault<People>();
            //var existingInfo = GetUserByEmailId(email);
            //if (existingInfo == null) return NotFound();
            //existingInfo.Name = people.Name;
            //existingInfo.Email = people.Email;
            existingInfo.Password  = password;
            existingInfo.Forgot_Password= forgotPassword;
            _context.SaveChanges();
            return Ok("Password Updated");
        }


        // ForGot Password 
        // [HttpPut("{email}")]   

        /*
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Reset_Password(int id, People people)
        {
            //if(!ModelState.IsValid) return BadRequest(ModelState);
            //if (id != people.Id) return BadRequest();
            _context.Entry(people).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        */

    }
}
