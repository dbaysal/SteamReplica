using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Interfaces;

namespace NLayer.Core.Models
{
    public abstract class BaseEntity : EFMarkupInterface
    {
        public int Id { get; set; }

    }
}
