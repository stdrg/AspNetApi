using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using WebApi.DAL.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VermittlersController : ControllerBase
    {
        private VermittlerRepository _vermittlerRepository;

        public VermittlersController(VermittlerRepository vermittlerRepository)
        {
            _vermittlerRepository = vermittlerRepository;
        }

        [HttpGet]
        public ActionResult<VermittlerDto> GetVermittler()
        {
            return Ok(_vermittlerRepository.GetAllVermittler());
        }

        [HttpGet("{id}")]
        public ActionResult<VermittlerDto> GetVermittler(int id)
        {
            var vermittlerDto = _vermittlerRepository.GetVermittler(id);

            if (vermittlerDto == null)
            {
                return NotFound();
            }

            return Ok(vermittlerDto);
        }

        [HttpPost]
        public ActionResult<Vermittler> PostVermittler([FromBody] VermittlerSetDto vermittler)
        {
            var result = _vermittlerRepository.PostVermittler(vermittler);
            if (result == null)
                return BadRequest();
            else
                return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult PutVermittler(long id, VermittlerSetDto newVermittler)
        {
            if (_vermittlerRepository.GetVermittler(id) == null)
                return NotFound();

            var result = _vermittlerRepository.PutVermittler(id, newVermittler);

            if (result != null)
                return NoContent();
            else
                return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVermittler(long id)
        {
            if (_vermittlerRepository.GetVermittler(id) == null)
                return NotFound();

            var result = _vermittlerRepository.DeleteVermittler(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
    }
}