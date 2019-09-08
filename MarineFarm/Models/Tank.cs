using System.ComponentModel.DataAnnotations;


namespace MarineFarm.Models
{
    public class Tank
    {
        [Key]
        public int TankId { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }


        public int NumberOfFish { get; set; }
    }
}
