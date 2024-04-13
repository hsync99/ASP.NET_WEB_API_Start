using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using rpgapi.Data;
using rpgapi.DTOS.Character;
using rpgapi.Models;

namespace rpgapi.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private DataContext _context;
        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;   
            _context = context;
        }
         private static List<Character> characters = new List<Character>{
            new Character(),
            new Character {Id = 1, Name = "Sam"},
            new Character {Id = 2, Name = "Fred"},
            new Character {Id = 3, Name = "Frodo"},
            new Character {Id = 4, Name = "Leo"},
            new Character {Id = 5, Name = "Greg"}
        };

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newcharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newcharacter);
            character.Id = characters.Max(x => x.Id) + 1;   
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse< List<GetCharacterDto>>>GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> dbCharacters = new List<Character>();
            try
            {
                 dbCharacters =  _context.Characters.ToList();
                serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            
            
            return serviceResponse;
        }

        public async Task <ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacters = _context.Characters.ToList();
            var character = dbCharacters.FirstOrDefault(c => c.Id == id) ?? new Character();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedcharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
               
                var character = characters.FirstOrDefault(c => c.Id == updatedcharacter.Id);
                if (character is null)
                {
                    throw new Exception($"Characted with id '{updatedcharacter.Id}' not found");
                }
               // _mapper.Map(updatedcharacter, character);
                character.Strength = updatedcharacter.Strength;
                character.Name = updatedcharacter.Name;
                character.Defense = updatedcharacter.Defense;
                character.Inteligence = updatedcharacter.Inteligence;
                character.HitPoints = updatedcharacter.HitPoints;
                character.Classs = updatedcharacter.Classs;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;                
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                
                var character = characters.First(c => c.Id == id);
                if (character is null)
                {
                    throw new Exception($"Characted with id '{id}' not found");
                }
                // _mapper.Map(updatedcharacter, character);
                characters.Remove(character);

                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

                
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}