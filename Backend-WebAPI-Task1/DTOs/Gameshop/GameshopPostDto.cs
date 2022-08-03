using Backend_WebAPI_Task1.DTOs.VideoGame;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.DTOs.Gameshop
{
    public class GameshopPostDto
    {
        public string Title { get; set; }
        public string Address { get; set; }
        // qiymetleri false da $, null da $$, true da ise $$$ dir
        public bool? PriceRange { get; set; }
        //public List<VideoGameListItemDto> VideoGames { get; set; }


    }
    public class GameshopPostDtoValidation : AbstractValidator<GameshopPostDto>
    {
        public GameshopPostDtoValidation()
        {
            RuleFor(g => g.Title).MaximumLength(50).WithMessage("max length 50").NotNull().WithMessage("can't be empty");
            RuleFor(g => g.Address).MaximumLength(50).WithMessage("max length 50").NotNull().WithMessage("can't be empty");
            
        }
    }
}
