using System.ComponentModel.DataAnnotations;

namespace ToysAndGames.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Range(typeof(int),"0","100")]
        public int AgeRestriction { get; set; }

        [MaxLength(50)]
        public string Company { get; set; }

        [Range(typeof(decimal), "0", "1000")]
        public decimal Price { get; set; }
    }
}
