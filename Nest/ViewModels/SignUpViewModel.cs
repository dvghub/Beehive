using Nest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class SignUpViewModel {
        public User User { get; set; }

        [Required ( ErrorMessage = "Please enter a password")]
        public string NewPassword { get; set; }

        [Required (ErrorMessage = "Please repeat your password")]
        public string RepeatPassword { get; set; }
    }
}