﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Gamesmarket.Domain.ViewModel.Game
{
    public class GameViewModel
    {//Model to simplify data transfer between service and controller
        public int Id { get; set; }

        [Required]
        [MaxLength]
        public string Name { get; set; }

        public string Developer { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string GameGenre { get; set; }

    }
}