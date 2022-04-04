using System.ComponentModel.DataAnnotations;

namespace VoyagesAPI.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [StringLength(60)]
        public string CountryName { get; set; } = string.Empty;
    }
}
