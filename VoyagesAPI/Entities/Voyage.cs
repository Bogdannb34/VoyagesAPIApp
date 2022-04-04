using System.ComponentModel.DataAnnotations;

namespace VoyagesAPI.Entities
{
    public class Voyage
    {
        [Key]
        public int VoyageId { get; set; }

        public int VoyageShipId { get; set; }

        public DateTime VoyageDate { get; set; }

        [StringLength(60)]
        public string VoyageDeparturePort { get; set; } = string.Empty;

        public DateTime VoyageStart { get; set; }

        [StringLength(60)]
        public string VoyageArrivalPort { get; set; } = string.Empty;

        public DateTime VoyageEnd { get; set; }
    }
}
