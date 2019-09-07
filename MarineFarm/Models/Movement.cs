using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarineFarm.Models
{
    public class Movement
    {
        [Key]
        public int MovementId { get; set; }

        [ForeignKey("Fish")]
        public int FishId { get; set; }

        [ForeignKey("Tank")]
        public int TankIdFrom { get; set; }

        [ForeignKey("Tank")]
        public int TankIdTo { get; set; }

    }
}
