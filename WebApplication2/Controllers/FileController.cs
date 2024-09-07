using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("readfile")]
        public IActionResult ReadFile()
        {
            FileStream file = null;

            try
            {
                // File opening and reading
                file = System.IO.File.Open("sample.txt", FileMode.Open);

                using (StreamReader reader = new StreamReader(file))
                {
                    var fileContent = reader.ReadToEnd();

                    // Return file content as response
                    return Ok(new { content = fileContent });
                }
            }

            catch (FileNotFoundException ex)
            {
                // Handle file not found error
                return NotFound(new { message = "File not found", details = ex.Message });
            }

            catch (Exception ex)
            {
                // Handle general exceptions
                return StatusCode(500, new { message = "An error occurred while reading the file", 
                    details = ex.Message });
            }
            finally
            {
                // Ensure the file is closed properly
                if (file != null)
                {
                    file.Close();
                }

                Console.WriteLine("File handling operation completed.");
            }
        }
    }
}
