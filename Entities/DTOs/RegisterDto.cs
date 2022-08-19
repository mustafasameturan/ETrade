using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RegisterDto : IDto
    {
        //Kullanıcıdan üye olurken istenen bilgiler.
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Kullanıcı ismi gereklidir.")]
        [Display(Name = "Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kullanıcı soyadı gereklidir.")]
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }

        [Display(Name = "Telefon Numarası:")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-Posta gereklidir.")]
        [Display(Name = "E-Posta: ")]
        [EmailAddress(ErrorMessage = "E-Posta adresiniz doğru formatta değil.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreniz gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
