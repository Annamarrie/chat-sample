using chat_server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace chat_server.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public static readonly Guid[] Ids =
        {
            new Guid("11111111-1111-1111-1111-111111111111"),
            new Guid("22222222-2222-2222-2222-222222222222"),
            new Guid("33333333-3333-3333-3333-333333333333"),
            new Guid("44444444-4444-4444-4444-444444444444"),
            new Guid("55555555-5555-5555-5555-555555555555"),
            new Guid("66666666-6666-6666-6666-666666666666"),
        };

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var data = new List<User>
            {
                CreateModel(Ids[0], "Suren", "Melqonyan"),
                CreateModel(Ids[1], "Armen", "Frangulyan"),
                CreateModel(Ids[2], "Karen", "Sargsyan"),
                CreateModel(Ids[3], "Ashot", "Karapetyan"),
                CreateModel(Ids[4], "Erik", "Mughdusyan"),
            };

            builder.HasData(data);
        }

        private User CreateModel(Guid id, string firstName, string lastName)
        {
            return new User
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}
