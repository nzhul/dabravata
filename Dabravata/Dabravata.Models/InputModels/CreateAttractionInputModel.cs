using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dabravata.Models.InputModels
{
    public class CreateAttractionInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името на атракцията е задължително:")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Невалидно име - Максимална дължина 250 символа, минимална 3")]
        [Display(Name = "Име:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Съдържанието е задължително!")]
        [AllowHtml]
        [Display(Name = "Съдържание:")]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Content { get; set; }

        [Display(Name = "Позиция:")]
        public int DisplayOrder { get; set; }

        public Image Image { get; set; }
    }
}
