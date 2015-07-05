﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dabravata.Models.InputModels
{
    public class CreateRoomInputModel
    {
        public CreateRoomInputModel()
        {
            this.RoomFeatures = new List<string>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Номера на стаята е задължителен!")]
        [Display(Name = "Номер:")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Името на стаята е задължително:")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Невалидно име - Максимална дължина 250 символа, минимална 3")]
        [Display(Name = "Име:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описанието е задължително!")]
        [AllowHtml]
        [Display(Name = "Описание на стаята:")]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }


        [Display(Name = "На Заглавна страница: ")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Покажи цената: ")]
        public bool IsPriceVisible { get; set; }

        [Display(Name = "Позиция: ")]
        public int DisplayOrder { get; set; }

        [Required(ErrorMessage = "Задължително!")]
        [Display(Name = "Категория")]
        public int SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<Image> Images { get; set; }

        [Display(Name = "Екстри: ")]
        public List<string> RoomFeatures { get; set; }
    }
}
