using System.ComponentModel.DataAnnotations;


namespace MarineFarm.Models
{
    public class Fish
    {
        [Key]
        public int FishId { get; set; }

        public string Weight { get; set; }

        public Tank Tank { get; set; }

    }
}
