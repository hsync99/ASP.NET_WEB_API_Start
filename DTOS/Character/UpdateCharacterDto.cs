using rpgapi.Models;

namespace rpgapi.DTOS.Character
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Masya";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 1;
        public int Inteligence { get; set; } = 10;

        public RpgClass Classs { get; set; } = RpgClass.Knight;
    }
}
