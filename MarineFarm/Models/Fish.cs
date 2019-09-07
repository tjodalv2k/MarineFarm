using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarineFarm.Models
{
    public class Fish
    {
        [Key]
        public int FishId { get; set; }

        public string Weight { get; set; }

        [ForeignKey("Tank")]
        public int TankId { get; set; }


    }
}
