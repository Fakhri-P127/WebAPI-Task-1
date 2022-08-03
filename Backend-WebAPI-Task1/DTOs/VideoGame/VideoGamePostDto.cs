using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_WebAPI_Task1.DTOs.VideoGame
{
    public class VideoGamePostDto
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public bool IsVisible { get; set; } 
    }

    public class VideoGamePostDtoValidation : AbstractValidator<VideoGamePostDto>
    {
        public VideoGamePostDtoValidation()
        {
            RuleFor(v => v.Company).NotNull().WithMessage("Please enter some value")
                .MaximumLength(30).WithMessage("Max characters are 30");
            RuleFor(v => v.Name).NotNull().WithMessage("Please enter some value")
                .MaximumLength(30).WithMessage("Max characters are 30");
            RuleFor(v => v.Price).NotNull().WithMessage("Please enter some value")
                .LessThanOrEqualTo(69.99M).WithMessage("One videogame can't cost more than 69.99")
                .GreaterThanOrEqualTo(0.99M).WithMessage("at this point make it free bro");
           

        }
    }
}
