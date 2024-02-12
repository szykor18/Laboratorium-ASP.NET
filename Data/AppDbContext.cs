using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<BranchEntity> Branches { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "employees.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // utworzenie id
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();

            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            // utworzenie ról
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    Id = ADMIN_ROLE_ID,
                    ConcurrencyStamp = ADMIN_ROLE_ID
                });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "user",
                    NormalizedName = "USER",
                    Id = USER_ROLE_ID,
                    ConcurrencyStamp = USER_ROLE_ID
                });

            // utworzenie użytkowników
            var admin = new IdentityUser()
            {
                Id = ADMIN_ID,
                Email = "admin@wsei.edu.pl",
                NormalizedEmail = "ADMIN@WSEI.EDU.PL",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            var user = new IdentityUser()
            {
                Id = USER_ID,
                Email = "user@wsei.edu.pl",
                NormalizedEmail = "USER@WSEI.EDU.PL",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "USER"
            };

            // haszowanie haseł
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();

            admin.PasswordHash = ph.HashPassword(admin, "admin");
            user.PasswordHash = ph.HashPassword(user, "user");

            // dodanie użytkowników
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);

            //przypisanie administratorowi roli admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID,
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID,
                });

            // Entity
            modelBuilder.Entity<BranchEntity>()
            .OwnsOne(e => e.Address);

            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.Branch)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.BranchId);

            modelBuilder.Entity<BranchEntity>().HasData(
    new BranchEntity()
    {
        BranchId = 1,
        Title = "Firma X",
    },
    new BranchEntity()
    {
        BranchId = 2,
        Title = "XYZ Spółka z o.o.",
    },
    new BranchEntity()
    {
        BranchId = 3,
        Title = "XYZ Spółka Akcyjna",
    },
    new BranchEntity()
    {
        BranchId = 4,
        Title = "XYZ Spółka komandytowa",
    },
    new BranchEntity()
    {
        BranchId = 5,
        Title = "Firma Y",
    }
);

            modelBuilder.Entity<BranchEntity>()
               .OwnsOne(e => e.Address)
               .HasData(
                   new
                   {
                       BranchEntityBranchId = 1,
                       City = "Kraków",
                       Street = "Korona",
                       Number = "123",
                       PostalCode = "00-015",
                       Region = "mazowieckie",
                       Country = "Polska"
                   },
                   new
                   {
                       BranchEntityBranchId = 2,
                       City = "Kraków",
                       Street = "Rynek Główny",
                       Number = "3",
                       PostalCode = "33-212",
                       Region = "Małopolskie",
                       Country = "Polska"
                   },
                   new
                   {
                       BranchEntityBranchId = 3,
                       City = "Warszawa",
                       Street = "Praska",
                       Number = "13",
                       PostalCode = "22-143",
                       Region = "Mazowieckie",
                       Country = "Polska"
                   },
                   new
                   {
                       BranchEntityBranchId = 4,
                       City = "Poznań",
                       Street = "Błotna",
                       Number = "15",
                       PostalCode = "41-320",
                       Region = "Wielkopolskie",
                       Country = "Polska"
                   },
                   new
                   {
                       BranchEntityBranchId = 5,
                       City = "Kraków",
                       Street = "Topolowa",
                       Number = "10",
                       PostalCode = "32-040",
                       Region = "Małopolskie",
                       Country = "Polska"
                   }
            );

            modelBuilder.Entity<EmployeeEntity>().HasData(
                // Firma XYZ
                new EmployeeEntity
                {
                    EmployeeId = 1,
                    Name = "Ewa",
                    LastName = "Maj",
                    PESEL = "76051112345",
                    Email = "ewa.maj@firmax.pl",
                    Phone = "500100200",
                    Position = 1,
                    BranchId = 1,
                    DateOfEmployment = new DateTime(2020, 01, 10)
                },
                new EmployeeEntity
                {
                    EmployeeId = 2,
                    Name = "Marcin",
                    LastName = "Zawadzki",
                    PESEL = "85012223456",
                    Email = "marcin.zawadzki@xyz.com",
                    Phone = "600200300",
                    Position = 2,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2021, 02, 15),
                    DateOfDismissal = new DateTime(2023, 11, 30)
                },
                new EmployeeEntity
                {
                    EmployeeId = 3,
                    Name = "Anna",
                    LastName = "Kowalczyk",
                    PESEL = "94021567890",
                    Email = "anna.kowalczyk@xyzsa.com",
                    Phone = "700300400",
                    Position = 3,
                    BranchId = 3,
                    DateOfEmployment = new DateTime(2022, 03, 20)
                },
                new EmployeeEntity
                {
                    EmployeeId = 4,
                    Name = "Krzysztof",
                    LastName = "Borowski",
                    PESEL = "87032145698",
                    Email = "krzysztof.borowski@xyzsk.com",
                    Phone = "800400500",
                    Position = 4,
                    BranchId = 4,
                    DateOfEmployment = new DateTime(2020, 04, 01)
                },
                new EmployeeEntity
                {
                    EmployeeId = 5,
                    Name = "Magdalena",
                    LastName = "Sikorska",
                    PESEL = "88040512345",
                    Email = "magdalena.sikorska@firmax.pl",
                    Phone = "900500600",
                    Position = 5,
                    BranchId = 5,
                    DateOfEmployment = new DateTime(2021, 05, 20),
                    DateOfDismissal = new DateTime(2023, 10, 10)
                },
                new EmployeeEntity
                {
                    EmployeeId = 6,
                    Name = "Tomasz",
                    LastName = "Nowak",
                    PESEL = "92050867890",
                    Email = "tomasz.nowak@xyz.com",
                    Phone = "910610710",
                    Position = 1,
                    BranchId = 1,
                    DateOfEmployment = new DateTime(2022, 06, 15)
                },
                new EmployeeEntity
                {
                    EmployeeId = 7,
                    Name = "Julia",
                    LastName = "Wójcik",
                    PESEL = "93061178901",
                    Email = "julia.wojcik@xyzsa.com",
                    Phone = "920720820",
                    Position = 3,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2023, 07, 05)
                }
            );
        }
    }
}
