using employeeProject.data;
using employeeProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employeeProject.Controllers
{
    [Route("files/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    { private readonly MainDbContext _context;
      public FilesController(MainDbContext context) => _context = context;
        [HttpGet("{user_name}")]
        public async Task<IEnumerable<Files>> GetFiles(string user_name)
        {
            
            var files_uploaded = await _context.Files.Where(f => f.Uploaded_To_Folder == user_name).ToListAsync();
            return files_uploaded;
            // return await _context.Files.ToListAsync();
        }

        // Creating new file 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFiles(Files file)
        {   //Returns 204NoContent error when a user already exits with same email
            // var user_already_exists = GetUserByEmailId(people.Email);
            // if (user_already_exists != null) return BadRequest();
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Update a File path
        //Update People info 
        [HttpPut]
        public IActionResult UpdateFileInfo(Files file)
        {
            if (!ModelState.IsValid) return BadRequest("Bad File request");
            var existingInfo = _context.Files.Where(r => r.Id == file.Id).FirstOrDefault<Files>();
            if (existingInfo == null) return NotFound();
            existingInfo.Uploaded_By_id = file.Uploaded_By_id;
            existingInfo.Uploaded_To_Folder = file.Uploaded_To_Folder;
            existingInfo.Uploaded_Path = file.Uploaded_Path;
            _context.SaveChanges();
            return Ok("Information Updated");
        }

    }
}
