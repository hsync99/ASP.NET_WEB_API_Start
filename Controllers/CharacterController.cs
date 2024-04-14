using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rpgapi.DTOS.Character;
using rpgapi.Models;
using rpgapi.Services;

namespace rpgapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }
       
        [HttpGet("GetList")]
        public async Task<ActionResult<List<GetCharacterDto>>> Get(){
            return Ok(_characterService.GetAllCharacters());
        }
        [HttpGet("GetSingle/{id}")]
        public async Task<ActionResult<GetCharacterDto>> GetSingle(int id){
            return Ok(_characterService.GetCharacterById(id));
        }
        [HttpPost("Add")]
        public async Task<ActionResult<List<GetCharacterDto>>> AddCharacted(AddCharacterDto newcharacter){
            
            return Ok(_characterService.AddCharacter(newcharacter));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<List<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("DeleteCharacter/{id}")]
        public async Task<ActionResult<GetCharacterDto>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}