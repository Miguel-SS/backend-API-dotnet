using APIBackend.Services;
using APIBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        public readonly APIDBContext _context;

        public PatientsController(APIDBContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> get_patients()
        {
            return await _context.Patient.ToListAsync();
        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Patient>> get_patient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);

            return (patient == null) ? NotFound() : patient;
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> post_patient(Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            } else
            {
                _context.Patient.Add(patient);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateException)
                {
                    // catch some exception
                    throw;
                }

                return CreatedAtAction("Patient created", patient);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete_patient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);

            if(patient == null)
            {
                return NotFound();
            } else
            {
                _context.Patient.Remove(patient);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
