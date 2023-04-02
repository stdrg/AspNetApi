using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using WebApi.DAL.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorieController : ControllerBase
    {
        private HistorieRepository _historieRepository;

        public HistorieController(HistorieRepository historieRepository)
        {
            _historieRepository = historieRepository;
        }

        [HttpGet("/vermittler/{vermittlerId}")]
        public ActionResult<VermittlerHistorieDto> GetVermittlerHistorie(long vermittlerId)
        {
            var result = _historieRepository.GetVermittlerHistory(vermittlerId);
            if (result == null) return NotFound();
            else return Ok(result);
        }

        [HttpGet("/adresse/{vermittlerId}")]
        public ActionResult<VermittlerHistorieDto> GetAdresseHistorie(long vermittlerId)
        {
            var result = _historieRepository.GetAddressHistory(vermittlerId);
            if (result == null) return NotFound();
            else return Ok(result);
        }
    }
}