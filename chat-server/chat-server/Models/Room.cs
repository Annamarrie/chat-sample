using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_server.Models
{
    public class Room : ChatBaseEntity
    {
        public string RoomName { get; set; }
        public DateTime Date { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
