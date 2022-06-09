using System;
using System.ComponentModel.DataAnnotations;

namespace LocVideo.ApplicationCore
{
    public class ClientLoc
    {
        [Key]
        public int IdClient { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public DateTime Birthdate { get; set; }

        public string Phone { get; set; }
    }
}
