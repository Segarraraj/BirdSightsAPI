using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdSightsController : ControllerBase
    {
        private IService<BirdSight> _birdSightService;

        private IValidator<BirdSight> _birdSightCreateValidator;
        private IValidator<Tuple<int, BirdSight>> _birdSightUpdateValidator;

        public BirdSightsController(IService<BirdSight> birdSightService,
            IValidator<BirdSight> birdSightCreateValidator,
            IValidator<Tuple<int, BirdSight>> birdSightUpdateValidator)
        {
            _birdSightService = birdSightService;
            
            _birdSightCreateValidator = birdSightCreateValidator;
            _birdSightUpdateValidator = birdSightUpdateValidator;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<BirdSight>>> Get()
        {
            return Ok(await _birdSightService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BirdSight?>> GetById(int id)
        {
            var birdSight = await _birdSightService.GetByIdAsync(id);

            if (birdSight == null)
                return NotFound();

            return Ok(birdSight);
        }

        [HttpPost]
        public async Task<ActionResult<BirdSight?>> Create(BirdSight birdSight)
        {
            var validationResult = _birdSightCreateValidator.Validate(birdSight);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var createdBirdSight = await _birdSightService.CreateAsync(birdSight);

            if (createdBirdSight == null)
                return BadRequest();

            return Ok(createdBirdSight);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BirdSight?>> Update(int id, BirdSight birdSight)
        {
            var validationResult = _birdSightUpdateValidator.Validate(new Tuple<int, BirdSight>(id, birdSight));

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var updatedBirdSight = await _birdSightService.UpdateAsync(id, birdSight);

            if (updatedBirdSight == null)
                return BadRequest();

            return Ok(updatedBirdSight);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BirdSight?>> Delete(int id)
        {
            var deletedBirdSight = await _birdSightService.DeleteAsync(id);

            if (deletedBirdSight == null)
                return BadRequest();

            return Ok(deletedBirdSight);
        }
    }
}
