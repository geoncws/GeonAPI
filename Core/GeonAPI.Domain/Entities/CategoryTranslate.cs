﻿using System.ComponentModel.DataAnnotations;
using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public partial class CategoryTranslate : Translate
    {
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public virtual Category Category { get; set; }
    }
}