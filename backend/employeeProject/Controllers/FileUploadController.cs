using employeeProject.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employeeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {

        /*
         *         public readonly MainDbContext _context;
            public RequestsController(MainDbContext context) => _context = context;
        */
        public readonly MainDbContext _context;
        public FileUploadController(MainDbContext context) => _context = context; 

        [HttpPost]
        [Route("saveFile/{fileName}/{uploaded_by_name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof (string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(IFormFile file, string fileName, string uploaded_by_name)
        {
            await WriteFile(file, fileName, uploaded_by_name, _context);

            return Ok("File Uploaded Successfully");
        }


        private static async Task<bool> WriteFile(IFormFile file, string file_Name, string uploaded_by_name, MainDbContext context)
        {
            bool isSaveSuccess = false;
            string fileName;
            try
            {
                var extension = "."+ file.FileName.Split('.')[file.FileName.Split(".").Length-1];
                fileName = file_Name + extension;
                var pathBuild = Path.Combine(Directory.GetCurrentDirectory(), "uploads\\"+uploaded_by_name);
                if(!Directory.Exists(pathBuild))
                {
                    Directory.CreateDirectory(pathBuild);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), pathBuild, fileName) ;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    isSaveSuccess = true;
                }
                /*
                 *             await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
                 * */
                Files fil = new Files
                {
                    File_Name = file_Name,
                    Uploaded_By_id = 1,
                    Uploaded_To_Folder= uploaded_by_name,
                    Uploaded_Path = path,
                };

                await context.Files.AddAsync(fil);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { }
            return isSaveSuccess;
        }
    }
}
