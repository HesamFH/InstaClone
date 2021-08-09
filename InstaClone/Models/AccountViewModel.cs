using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InstaClone.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [MaxLength(50, ErrorMessage = "نام کاربری نمی تواند بیش از 50 حرف داشته باشد")]
        [MinLength(5, ErrorMessage = "نام کاربری نمی تواند کمتر از 5 حرف داشته باشد")]
        [DisplayName("نام کاربری")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "ایمیل نمی تواند بیش از 200 حرف داشته باشد")]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور را وارد کنید")]
        [MaxLength(50, ErrorMessage = "رمز عبور نمی تواند بیش از 50 حرف داشته باشد")]
        [MinLength(8, ErrorMessage = "رمز عبور نمی تواند کمتر از 8 حرف داشته باشد")]
        [DataType(DataType.Password)]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا تکرار رمز عبور را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه عبور مطابقت ندارد")]
        [DisplayName("تکرار رمز عبور")]
        public string RePassword { get; set; }

        [DisplayName("عکس پروفایل")]
        public IFormFile ProfilePic { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور را وارد کنید")]
        [DataType(DataType.Password)]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }

        [DisplayName("مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}

