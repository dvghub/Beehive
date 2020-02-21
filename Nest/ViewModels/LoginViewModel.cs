﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class LoginViewModel {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}