using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.DTOs.Gameshop
{
    public class GameshopGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        // qiymetleri false da $, null da $$, true da ise $$$ dir
        public bool? PriceRange { get; set; }


    }
}
