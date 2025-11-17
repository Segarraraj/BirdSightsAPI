using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private IService<Bird> _birdService;

        private IValidator<Bird> _birdCreateValidator;

        public BirdsController(IService<Bird> birdService, 
            IValidator<Bird> birdCreateValidator)
        {
            _birdService = birdService;
            _birdCreateValidator = birdCreateValidator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _birdService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bird?>> GetById(int id)
        {
            var bird = await _birdService.GetByIdAsync(id);

            if (bird == null)
                return NotFound(null);

            return Ok(bird);
        }

        [HttpPost]
        public async Task<ActionResult<Bird?>> Create(Bird bird)
        {
            var validationResult = _birdCreateValidator.Validate(bird);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var createdBird = await _birdService.CreateAsync(bird);

            if (createdBird == null)
                return BadRequest();

            return Ok(createdBird);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Bird?>> Update(int id, Bird bird)
        {
            var updatedBird = await _birdService.UpdateAsync(id, bird);

            if (updatedBird == null)
                return BadRequest();

            return Ok(updatedBird);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bird?>> Delete(int id)
        {
            var deletedBird = await _birdService.DeleteAsync(id);
            
            if (deletedBird == null)
                return BadRequest();

            return Ok(deletedBird);
        }
    }
}
