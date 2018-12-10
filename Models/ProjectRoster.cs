using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    public class ProjectRoster
    {
        public int ID {get; set;}
        public string ProjectParticipantID { get; set; }
        public ProjectParticipant ProjectParticipant { get; set; }
        public string ProjectID { get; set; }
        public Project Project { get; set; }
    }
}
