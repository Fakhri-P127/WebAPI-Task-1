using Backend_WebAPI_Task1.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.Models
{
    public class VideoGame:BaseEntity
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public bool IsVisible { get; set; }
        public int? GameshopId { get; set; }
        public Gameshop Gameshop{ get; set; }


    }
}
