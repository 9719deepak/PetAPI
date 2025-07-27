using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PetAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetController(AppDbContext context) => _context = context;

        [HttpGet]
        [Route("getpets")]
        public ActionResult<IEnumerable<PetModel>> GetPets() => _context.Pets.ToList();

        [HttpPost]
        [Route("addpet")]
        public IActionResult AddPet(PetModel pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return Ok(pet);
        }

        [HttpPut]
        [Route("{id}/found")]
        public IActionResult MarkAsFound(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null) return NotFound();
            pet.IsFound = true;
            _context.SaveChanges();
            return Ok(pet);
        }

        [HttpDelete]
        [Route("removeentry")]
        public async Task<IActionResult> RemovePetEntry(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound(); 
            }
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
