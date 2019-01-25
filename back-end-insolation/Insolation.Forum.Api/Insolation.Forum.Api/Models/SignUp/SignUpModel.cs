using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insolation.Forum.Api.Models.SignUp
{
    public class SignUpModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required, Compare("Senha")]
        public string ConfirmarSenha { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
    }
}