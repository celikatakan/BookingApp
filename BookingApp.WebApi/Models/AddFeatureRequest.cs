using System.ComponentModel.DataAnnotations;

namespace BookingApp.WebApi.Models
{
    public class AddFeatureRequest
    {
        [Required]
        [Length(5, 50)]
        public string Title { get; set; }
    }
}
