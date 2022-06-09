﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocVideo.ApplicationCore
{
    public class ClientLocDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public DateTime Birthdate { get; set; }

        public string Phone { get; set; }
    }
}
