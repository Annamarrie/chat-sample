using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_server.Models
{
    public class User : ChatBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Room> Rooms { get; set; }

    }
}
