using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    public class ProjectDetailViewModel
    {

        public Project TheProject {get; set;}

        public List<Client> ProjectClients { get; set; }
        
        public List<Member> ProjectMembers { get; set; }

        
    }
}