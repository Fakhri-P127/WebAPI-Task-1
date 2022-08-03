using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.DTOs.Gameshop
{
    public class GameshopListDto
    {
        public List<GameshopListItemDto> GameshopListItemDtos { get; set; }
        public int TotalGamesCount{ get; set; }
    }
}
