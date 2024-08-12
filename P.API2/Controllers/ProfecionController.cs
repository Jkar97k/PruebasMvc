using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P.Interfaces;
using P.Repository;

namespace P.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfecionController : ControllerBase
    {
        private readonly IProfesionRepository _profesionRepository;

        private readonly IMapper _mapper;

        public ProfecionController(IProfesionRepository profesionRepository, IMapper mapper)
        {
            _profesionRepository = profesionRepository;
            _mapper = mapper;
        }

        [HttpGet("GetProfesiones")]
        public async Task<IActionResult> Get()
        {
            var data = await _profesionRepository.Get();
            var profesion = _mapper.Map<List<ProfesionDTO>>(data);
            return Ok(profesion);  // Usamos Ok() para devolver la lista como IActionResult
        }

    }
}
