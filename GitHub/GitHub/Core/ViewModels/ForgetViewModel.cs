﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GitHub.Core.ViewModels
{
    public class ForgetViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}