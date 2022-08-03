using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.DTOs.VideoGame
{
    public class VideoGameListDto
    {
        public List<VideoGameListItemDto> VideoGameListItemDtos { get; set; }
        public int TotalCount { get; set; }

    }
}
