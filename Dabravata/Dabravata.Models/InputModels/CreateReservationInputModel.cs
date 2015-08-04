using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dabravata.Models.InputModels
{
    public class CreateReservationInputModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Задължително посочете датата на настаняване!")]
        [Display(Name = "Дата на настаняване:")]
        public DateTime ArrivalDate { get; set; }

        [Required(ErrorMessage = "Задължително посочете датата на напускане!")]
        [Display(Name = "Дата на напускане:")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Посочете брой стаи!")]
        [Range(1, int.MaxValue, ErrorMessage = "Моля въведете валидно число!")]
        [Display(Name = "Брой на наетите стаи:")]
        public int RoomsCount { get; set; }

        [Required(ErrorMessage = "Задължително въведете брой възрастни!")]
        [Range(1, int.MaxValue, ErrorMessage = "Моля въведете валидно число!")]
        [Display(Name = "Брой възрастни:")]
        public int Adults { get; set; }

        [Display(Name = "Брой деца:")]
        public int Childs { get; set; }

        public bool IsConfirmed { get; set; }

        [Display(Name = "Име на наемателя:")]
        public string CustomerName { get; set; }

        [Display(Name = "Телефон на наемателя:")]
        public string CustomerPhone { get; set; }

        // TODO: Add Rooms CheckboxList!

    }
}
