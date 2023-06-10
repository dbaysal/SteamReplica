using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Interfaces;

namespace NLayer.Core.Models
{
    public class UserGame : EFMarkupInterface
    {
        public float PlayTime { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public User User { get; set; }
    }
}
