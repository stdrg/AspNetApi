using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using WebApi.DAL.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresseController : ControllerBase
    {
        private AdressenRepository _adressenRepository;

        public AdresseController(AdressenRepository adressenRepository)
        {
            _adressenRepository = adressenRepository;
        }

        [HttpGet]
        public ActionResult<VermittlerDto> GetAdressen()
        {
            return Ok(_adressenRepository.GetAllAdressen());
        }

        [HttpGet("{id}")]
        public ActionResult<VermittlerDto> GetAdresse(int id)
        {
            var vermittlerDto = _adressenRepository.GetAdresse(id);

            if (vermittlerDto == null)
            {
                return NotFound();
            }

            return Ok(vermittlerDto);
        }

        [HttpPost("{vermittlerId}")]
        public ActionResult<Adresse> PostAdresse(AdresseSetDto adresse, long vermittlerId)
        {
            var result = _adressenRepository.PostAdresse(adresse, vermittlerId);
            if (result == null)
                return BadRequest();
            else
                return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult PutAdresse(long id, AdresseSetDto newAdresse)
        {
            if (_adressenRepository.GetAdresse(id) == null)
                return NotFound();

            var result = _adressenRepository.PutAdresse(id, newAdresse);

            if (result != null)
                return NoContent();
            else
                return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdresse(long id)
        {
            if (_adressenRepository.GetAdresse(id) == null)
                return NotFound();

            var result = _adressenRepository.DeleteAdresse(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
    }
}