using System.ComponentModel.DataAnnotations;

namespace Agenzia_viaggio_mvc.Models
{
    public class Tour {
        [Key]
        public int TourId { get; set; }
        [StringLength(50)]
        public string Name { get; set;}
        public string Description { get; set;}
        public int Days { get; set;}
        public int Destinations { get; set;}
        public decimal Price { get; set;}
        public string ImageUrl { get; set;}
        public int? ColorCard { get; set;}

        public string GetFormattedPrice() => Price.ToString("0.00");
        public Tour() { }
        public Tour(int tourId, string name, string description, int days, int destinations, string imageUrl, int? colorCard) {
            TourId = tourId;
            Name = name;
            Description = description;
            Days = days;
            Destinations = destinations;
            ImageUrl = imageUrl;
            ColorCard = colorCard;

        }
    }
}
