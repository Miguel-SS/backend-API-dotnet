using APIBackend.Services;
using APIBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Metadata;

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
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patient.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);

            return (patient == null) ? NotFound() : patient;
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Patient.Add(patient);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    // catch some exception
                    throw;
                }

                return CreatedAtAction("Patient created", new { id = patient.Id }, patient);
            }

        }

        [HttpPut]
        public async Task<IActionResult> PutPatient(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // Patch method maybe comming soon
        // this method partially or completely update an object in the db
        //[HttpPatch("{id}")]
        //public async Task<IActionResult> PatchPatient(int id, Patient patient)
        //{
        //    var old_patient = await _context.Patient.FindAsync(id);

        //    foreach (var item in patient.GetType().GetProperties())
        //    {

        //        Console.WriteLine(item.GetValue(patient));


        //    }

        //    _context.Entry(patient).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
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
