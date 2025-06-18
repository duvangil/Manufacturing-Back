using MF.Domain.Entities;
using MF.Domain.Interfaces.Services;
using MF.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MF.Infrastructure.SeedDB
{
    public class SeedDB
    {
        public static async Task InitializeAsync(ManufacturingContext context, IPasswordHasher passwordHasher)
        {
            // Aplicar migraciones si es necesario
            await context.Database.MigrateAsync();

            // Seed de ElaborationTypes
            if (!context.ElaborationTypes.Any())
            {
                context.ElaborationTypes.AddRange(
                    new ElaborationType { Name = "Elaborado a mano" },
                    new ElaborationType { Name = "Elaborado a mano y máquina" }
                );
            }

            // Seed de Users
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Username = "admin",
                    PasswordHash = passwordHasher.Hash("admin123"),
                    Role = "Admin",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,

                });
            }

            await context.SaveChangesAsync();
        }
    }
}
