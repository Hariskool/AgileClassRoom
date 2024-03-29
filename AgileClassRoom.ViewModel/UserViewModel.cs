﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Contactno { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
