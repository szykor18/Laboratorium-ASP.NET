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
        public DbSet<DepartmentEntity> Branches { get; set; }
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
            modelBuilder.Entity<DepartmentEntity>()
            .OwnsOne(e => e.Address);

            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.Branch)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.BranchId);

            modelBuilder.Entity<DepartmentEntity>().HasData(
    new DepartmentEntity()
    {
        BranchId = 1,
        Title = "Firma XYZ",
    },
    new DepartmentEntity()
    {
        BranchId = 2,
        Title = "ABC Sp. z o.o.",
    },
    new DepartmentEntity()
    {
        BranchId = 3,
        Title = "Inicjatywa Polska",
    },
    new DepartmentEntity()
    {
        BranchId = 4,
        Title = "Tech Innovators",
    },
    new DepartmentEntity()
    {
        BranchId = 5,
        Title = "Nowoczesne Rozwiązania",
    }
);

            modelBuilder.Entity<DepartmentEntity>()
               .OwnsOne(e => e.Address)
               .HasData(
                   new
                   {
                       BranchEntityBranchId = 1,
                       City = "Warszawa",
                       Street = "Marszałkowska",
                       Number = "123",
                       PostalCode = "00-015",
                       Region = "mazowieckie",
                       Country = "Polska"
                   },
                   new
                   {
                       BranchEntityBranchId = 2,
                       City = "Kraków",
                       Street = "Wawel",
                       Number = "7",
                       PostalCode = "31-001",
                       Region = "małopolskie",
                       Country = "Polska"
                   },
                   new
                   {
                       BranchEntityBranchId = 3,
                       City = "Gdańsk",
                       Street = "Długa",
                       Number = "22",
                       PostalCode = "80-827",
                       Region = "pomorskie",
                       Country = "Polska"
                   },
                   new
                   {
                       BranchEntityBranchId = 4,
                       City = "Wrocław",
                       Street = "Rynek",
                       Number = "15",
                       PostalCode = "50-101",
                       Region = "dolnośląskie",
                       Country = "Polska"
                   },
                   new
                   {
                       BranchEntityBranchId = 5,
                       City = "Poznań",
                       Street = "Święty Marcin",
                       Number = "80",
                       PostalCode = "61-809",
                       Region = "wielkopolskie",
                       Country = "Polska"
                   }
            );

            modelBuilder.Entity<EmployeeEntity>().HasData(
                // Firma XYZ
                new EmployeeEntity()
                {
                    EmployeeId = 1,
                    Name = "Jan",
                    LastName = "Kowalski",
                    PESEL = "80010112345",
                    Email = "jan.kowalski@firmaxyz.com",
                    Phone = "123456789",
                    Position = 1,
                    BranchId = 1,
                    DateOfEmployment = new DateTime(2010, 5, 15)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 2,
                    Name = "Anna",
                    LastName = "Nowak",
                    PESEL = "90020223456",
                    Email = "anna.nowak@firmaxyz.com",
                    Phone = "987654321",
                    Position = 2,
                    BranchId = 1,
                    DateOfEmployment = new DateTime(2015, 8, 20),
                    DateOfDismissal = new DateTime(2023, 12, 31)
                },
                // ABC Sp. z o.o.
                new EmployeeEntity()
                {
                    EmployeeId = 3,
                    Name = "Michał",
                    LastName = "Wiśniewski",
                    PESEL = "82030334567",
                    Email = "michal.wisniewski@abc.com",
                    Phone = "234567891",
                    Position = 1,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2012, 3, 10)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 4,
                    Name = "Katarzyna",
                    LastName = "Lewandowska",
                    PESEL = "85040445678",
                    Email = "katarzyna.lewandowska@abc.com",
                    Phone = "198765432",
                    Position = 3,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2018, 6, 25),
                    DateOfDismissal = new DateTime(2024, 2, 28)
                },
                // Inicjatywa Polska
                new EmployeeEntity()
                {
                    EmployeeId = 5,
                    Name = "Piotr",
                    LastName = "Duda",
                    PESEL = "83050556789",
                    Email = "piotr.duda@inicjatywa.pl",
                    Phone = "543216789",
                    Position = 1,
                    BranchId = 3,
                    DateOfEmployment = new DateTime(2013, 7, 5)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 6,
                    Name = "Alicja",
                    LastName = "Jankowska",
                    PESEL = "84060667890",
                    Email = "alicja.jankowska@inicjatywa.pl",
                    Phone = "876543210",
                    Position = 4,
                    BranchId = 3,
                    DateOfEmployment = new DateTime(2019, 9, 30)
                },
                // Tech Innovators
                new EmployeeEntity()
                {
                    EmployeeId = 7,
                    Name = "Łukasz",
                    LastName = "Kamiński",
                    PESEL = "81070778901",
                    Email = "lukasz.kaminski@techinnovators.com",
                    Phone = "654321098",
                    Position = 1,
                    BranchId = 4,
                    DateOfEmployment = new DateTime(2011, 11, 11)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 8,
                    Name = "Magdalena",
                    LastName = "Zając",
                    PESEL = "83080889012",
                    Email = "magdalena.zajac@techinnovators.com",
                    Phone = "321098765",
                    Position = 5,
                    BranchId = 4,
                    DateOfEmployment = new DateTime(2017, 12, 20),
                    DateOfDismissal = new DateTime(2023, 6, 30)
                },
                // Nowoczesne Rozwiązania
                new EmployeeEntity()
                {
                    EmployeeId = 9,
                    Name = "Tomasz",
                    LastName = "Piotrowski",
                    PESEL = "84090990123",
                    Email = "tomasz.piotrowski@nowoczesne.pl",
                    Phone = "432109876",
                    Position = 1,
                    BranchId = 5,
                    DateOfEmployment = new DateTime(2014, 10, 1)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 10,
                    Name = "Monika",
                    LastName = "Adamczyk",
                    PESEL = "87010101234",
                    Email = "monika.adamczyk@nowoczesne.pl",
                    Phone = "210987654",
                    Position = 6,
                    BranchId = 5,
                    DateOfEmployment = new DateTime(2020, 11, 15)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 11,
                    Name = "Karolina",
                    LastName = "Wójcik",
                    PESEL = "88020212345",
                    Email = "karolina.wojcik@firmaxyz.com",
                    Phone = "345678912",
                    Position = 2,
                    BranchId = 1,
                    DateOfEmployment = new DateTime(2016, 3, 18)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 12,
                    Name = "Artur",
                    LastName = "Kaczmarek",
                    PESEL = "90030323456",
                    Email = "artur.kaczmarek@firmaxyz.com",
                    Phone = "456789123",
                    Position = 4,
                    BranchId = 1,
                    DateOfEmployment = new DateTime(2017, 8, 22),
                    DateOfDismissal = new DateTime(2022, 10, 31)
                },
                // ABC Sp. z o.o. (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 13,
                    Name = "Karol",
                    LastName = "Zieliński",
                    PESEL = "89040434567",
                    Email = "karol.zielinski@abc.com",
                    Phone = "567891234",
                    Position = 3,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2015, 4, 9)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 14,
                    Name = "Natalia",
                    LastName = "Walczak",
                    PESEL = "91050545678",
                    Email = "natalia.walczak@abc.com",
                    Phone = "678912345",
                    Position = 5,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2019, 9, 15)
                },
                // Inicjatywa Polska (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 15,
                    Name = "Marcin",
                    LastName = "Szymański",
                    PESEL = "92060656789",
                    Email = "marcin.szymanski@inicjatywa.pl",
                    Phone = "789123456",
                    Position = 2,
                    BranchId = 3,
                    DateOfEmployment = new DateTime(2016, 6, 28)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 16,
                    Name = "Patrycja",
                    LastName = "Dębska",
                    PESEL = "93070767890",
                    Email = "patrycja.debska@inicjatywa.pl",
                    Phone = "891234567",
                    Position = 4,
                    BranchId = 3,
                    DateOfEmployment = new DateTime(2020, 11, 10)
                },
                // Tech Innovators (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 17,
                    Name = "Damian",
                    LastName = "Pawlak",
                    PESEL = "94080878901",
                    Email = "damian.pawlak@techinnovators.com",
                    Phone = "912345678",
                    Position = 2,
                    BranchId = 4,
                    DateOfEmployment = new DateTime(2018, 12, 5)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 18,
                    Name = "Aleksandra",
                    LastName = "Mazur",
                    PESEL = "95090989012",
                    Email = "aleksandra.mazur@techinnovators.com",
                    Phone = "123456789",
                    Position = 3,
                    BranchId = 4,
                    DateOfEmployment = new DateTime(2021, 3, 20)
                },
                // Nowoczesne Rozwiązania (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 19,
                    Name = "Rafał",
                    LastName = "Witkowski",
                    PESEL = "96101090123",
                    Email = "rafal.witkowski@nowoczesne.pl",
                    Phone = "234567891",
                    Position = 2,
                    BranchId = 5,
                    DateOfEmployment = new DateTime(2018, 5, 7)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 20,
                    Name = "Wiktoria",
                    LastName = "Baran",
                    PESEL = "97111101234",
                    Email = "wiktoria.baran@nowoczesne.pl",
                    Phone = "345678912",
                    Position = 4,
                    BranchId = 5,
                    DateOfEmployment = new DateTime(2022, 8, 14)
                },
                // Firma XYZ (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 21,
                    Name = "Marta",
                    LastName = "Lis",
                    PESEL = "98121212345",
                    Email = "marta.lis@firmaxyz.com",
                    Phone = "456789123",
                    Position = 3,
                    BranchId = 1,
                    DateOfEmployment = new DateTime(2017, 10, 12)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 22,
                    Name = "Paweł",
                    LastName = "Olszewski",
                    PESEL = "99010123456",
                    Email = "pawel.olszewski@firmaxyz.com",
                    Phone = "567891234",
                    Position = 5,
                    BranchId = 1,
                    DateOfEmployment = new DateTime(2020, 2, 28)
                },
                // ABC Sp. z o.o. (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 23,
                    Name = "Joanna",
                    LastName = "Krawczyk",
                    PESEL = "00020234567",
                    Email = "joanna.krawczyk@abc.com",
                    Phone = "678912345",
                    Position = 4,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2018, 4, 3)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 24,
                    Name = "Kamil",
                    LastName = "Piotrowicz",
                    PESEL = "01030345678",
                    Email = "kamil.piotrowicz@abc.com",
                    Phone = "789123456",
                    Position = 6,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2021, 7, 20)
                },
                // Inicjatywa Polska (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 25,
                    Name = "Agnieszka",
                    LastName = "Jastrzębska",
                    PESEL = "02040456789",
                    Email = "agnieszka.jastrzebska@inicjatywa.pl",
                    Phone = "891234567",
                    Position = 3,
                    BranchId = 3,
                    DateOfEmployment = new DateTime(2017, 9, 8)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 26,
                    Name = "Dawid",
                    LastName = "Grabowski",
                    PESEL = "03050567890",
                    Email = "dawid.grabowski@inicjatywa.pl",
                    Phone = "912345678",
                    Position = 5,
                    BranchId = 3,
                    DateOfEmployment = new DateTime(2020, 11, 5)
                },
                // Tech Innovators (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 27,
                    Name = "Klaudia",
                    LastName = "Wojciechowska",
                    PESEL = "04060678901",
                    Email = "klaudia.wojciechowska@techinnovators.com",
                    Phone = "123456789",
                    Position = 4,
                    BranchId = 4,
                    DateOfEmployment = new DateTime(2019, 1, 15)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 28,
                    Name = "Szymon",
                    LastName = "Nowicki",
                    PESEL = "05070789012",
                    Email = "szymon.nowicki@techinnovators.com",
                    Phone = "234567891",
                    Position = 6,
                    BranchId = 4,
                    DateOfEmployment = new DateTime(2022, 4, 30)
                },
                // Nowoczesne Rozwiązania (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 29,
                    Name = "Aleksander",
                    LastName = "Kaczmarczyk",
                    PESEL = "06080890123",
                    Email = "aleksander.kaczmarczyk@nowoczesne.pl",
                    Phone = "345678912",
                    Position = 3,
                    BranchId = 5,
                    DateOfEmployment = new DateTime(2019, 6, 7)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 30,
                    Name = "Kinga",
                    LastName = "Grabowska",
                    PESEL = "07090901234",
                    Email = "kinga.grabowska@nowoczesne.pl",
                    Phone = "456789123",
                    Position = 5,
                    BranchId = 5,
                    DateOfEmployment = new DateTime(2022, 9, 14)
                },
                // Firma XYZ (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 31,
                    Name = "Karol",
                    LastName = "Nowak",
                    PESEL = "08010112345",
                    Email = "karol.nowak@firmaxyz.com",
                    Phone = "567891234",
                    Position = 3,
                    BranchId = 1,
                    DateOfEmployment = new DateTime(2018, 2, 15),
                    DateOfDismissal = new DateTime(2024, 1, 31)
                },
                // ABC Sp. z o.o. (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 32,
                    Name = "Zofia",
                    LastName = "Kowalczyk",
                    PESEL = "08121223456",
                    Email = "zofia.kowalczyk@abc.com",
                    Phone = "678912345",
                    Position = 2,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2019, 10, 10)
                },
                new EmployeeEntity()
                {
                    EmployeeId = 33,
                    Name = "Marek",
                    LastName = "Lisowski",
                    PESEL = "09030334567",
                    Email = "marek.lisowski@abc.com",
                    Phone = "789123456",
                    Position = 5,
                    BranchId = 2,
                    DateOfEmployment = new DateTime(2021, 5, 20),
                    DateOfDismissal = new DateTime(2024, 3, 15)
                },
                // Inicjatywa Polska (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 34,
                    Name = "Julia",
                    LastName = "Krawiec",
                    PESEL = "10040445678",
                    Email = "julia.krawiec@inicjatywa.pl",
                    Phone = "891234567",
                    Position = 1,
                    BranchId = 3,
                    DateOfEmployment = new DateTime(2020, 7, 8),
                    DateOfDismissal = new DateTime(2023, 6, 30)
                },
                // Tech Innovators (kontynuacja)
                new EmployeeEntity()
                {
                    EmployeeId = 35,
                    Name = "Krzysztof",
                    LastName = "Zając",
                    PESEL = "10150556789",
                    Email = "krzysztof.zajac@techinnovators.com",
                    Phone = "912345678",
                    Position = 3,
                    BranchId = 4,
                    DateOfEmployment = new DateTime(2021, 2, 5)
                }
            );
        }
    }
}
