using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.ResponseDTOs
{
    public class GameDisplayResponse
    {
	    public int Id { get; set; }
        public string Title { get; set; }
        public float AveragePlayTime { get; set; }
        public string ImageURL { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public float Price { get; set; }
    }
}
