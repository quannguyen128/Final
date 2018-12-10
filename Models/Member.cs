using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    public class Member : ProjectParticipant
    {
        [Display(Name = "Major")]                
        public string Major {get; set;}
    }
}