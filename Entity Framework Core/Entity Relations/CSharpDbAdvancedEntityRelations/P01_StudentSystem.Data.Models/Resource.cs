﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public ResourceType ResourceType { get; set; }
        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

    }

    public enum ResourceType
    {
        Video = 0,
        Presentation = 1,
        Document = 2,
        Other = 3
    }
}
