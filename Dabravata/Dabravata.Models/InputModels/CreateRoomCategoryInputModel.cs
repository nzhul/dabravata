﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dabravata.Models.InputModels
{
    public class CreateRoomCategoryInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името на категорията е задължително:")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Невалидно име - Максимална дължина 250 символа, минимална 3")]
        [Display(Name = "Име:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описание е задължително!")]
        [AllowHtml]
        [Display(Name = "Описание:")]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Description { get; set; }
    }
}
