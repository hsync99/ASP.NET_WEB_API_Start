using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpgapi.DTOS.Character;
using rpgapi.Models;

namespace rpgapi.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>>GetAllCharacters(); 
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task <ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newcharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedcharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}