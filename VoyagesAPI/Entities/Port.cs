using System.ComponentModel.DataAnnotations;

namespace VoyagesAPI.Entities
{
    public class Port
    {
        [Key]
        public int PortId { get; set; }

        [StringLength(100)]
        public string PortName { get; set; } = string.Empty;

        public int CountryId { get; set; }

        public Country? Country { get; set; }

    }
}
