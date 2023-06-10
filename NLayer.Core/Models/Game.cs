using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Game : BaseEntity
    {
        public string Title { get; set; }
        public float AveragePlayTime { get; set; }
        public int GenreId { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public Genre Genre { get; set; }
        public List<Basket> Baskets { get; set; }
        public float Price { get; set; }
	}
}
