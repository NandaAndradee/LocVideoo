using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocVideo.ApplicationCore.Dto
{
    public class ClientEmailCPFDto
    {
        public int IdClient { get; set; }

        public string NameUser { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public DateTime Birthdate { get; set; }

        public string Phone { get; set; }
    }
}
