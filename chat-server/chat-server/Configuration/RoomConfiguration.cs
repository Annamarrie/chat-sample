using chat_server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_server.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public static readonly Guid[] Ids =
        {
            new Guid("77777777-7777-7777-7777-777777777777"),
            new Guid("88888888-8888-8888-8888-888888888888"),
        };

        public void Configure(EntityTypeBuilder<Room> builder)
        {
            var data = new List<Room>
            {
                CreateModel(Ids[0], "Room1", DateTime.UtcNow),
                CreateModel(Ids[1], "Room2", DateTime.UtcNow)
            };

            builder.HasData(data);
        }

        private Room CreateModel(Guid id, string roomName, DateTime date)
        {
            return new Room
            {
                Id = id,
                RoomName = roomName,
                Date = date
            };
        }
    }
}
