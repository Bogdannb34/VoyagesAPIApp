using System.ComponentModel.DataAnnotations;

namespace VoyagesAPI.Entities
{
    public class Ship
    {
        [Key]
        public int ShipId { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; } = string.Empty;

        public float ShipSpeedMax { get; set; }
    }
}
