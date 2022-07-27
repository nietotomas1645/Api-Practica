﻿using System.ComponentModel.DataAnnotations;

namespace UniversityBackend.Models.DataModels
{

    public enum Level
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }
    public class Course: BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
        public Level Level { get; set; }= Level.Basic;

        [Required]
        public ICollection<Category> Categories { get; set; } =new List<Category>();

        // MINUTO -15:20 ACA ME QUEDE!


    }
}