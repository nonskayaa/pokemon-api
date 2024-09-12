namespace PokemonApi.Entities
{
    public class Pokemon
    {
        public int Id { get; set; } 
        
        public required string Name { get; set; } 
        
        public string Type { get; set; } = "Unknown";
        
        public int Level { get; set; }  = 1;
        
        public int HitPoints { get; set; } = 0;
        
        public int Attack { get; set; } = 0;
    }
}


