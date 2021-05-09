using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public int brandid { get; set; }
        public int colorid { get; set; }
        public string modelyear { get; set; }
        public int dailyprice { get; set; }
        public string description { get; set; }
    }
}
