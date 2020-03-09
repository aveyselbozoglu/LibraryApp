using LibraryApp.Entities;
using System;
using System.Data.Entity;

namespace LibraryApp.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var user = new User()
            {
                Name = "John",
                Surname = "Thomas",
                IsAdmin = true,
                Email = "johnthomas@gmail.com",
                Password = "123",
                ProfileImageFileName = "eagle.png",
                Username = "jthomas"
            };
            var user2 = new User()
            {
                Name = "Michael",
                Surname = "James",
                IsAdmin = true,
                Email = "michaeljames@gmail.com",
                Password = "1232",
                ProfileImageFileName = "hawk.jpg",
                Username = "mjames"
            };
            context.Users.Add(user);
            context.Users.Add(user2);
            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                var cat = new Category()
                {
                    Name = Faker.CompanyFaker.Name(),
                };
                context.Categories.Add(cat);

                for (int j = 0; j < Faker.NumberFaker.Number(0, 5); j++)
                {
                    var book = new Book()
                    {
                        Author = Faker.NameFaker.Name(),
                        Category = cat,
                        Isbn = Faker.NumberFaker.Number(0, Int32.MaxValue).ToString(),
                        Language = "TR",
                        Name = Faker.NameFaker.FemaleFirstName(),
                        PublishedDate = DateTime.Now,
                        Summary = Faker.TextFaker.Sentences(2),
                        PageCount = Faker.NumberFaker.Number(50, 500),
                        IsAvailable = true
                    };

                    context.Books.Add(book);

                    var borrow = new Borrow()
                    {
                        Book = book,
                        BorrowedTime = DateTime.Now,
                        IsLent = false,
                        LentTime = DateTime.Now.AddDays(15),
                        User = user
                    };
                    context.Borrows.Add(borrow);
                }

                context.SaveChanges();
            }

            var address = new Address()
            {
                BuildingNo = "x",
                City = "x",
                District = "x",
                Street = "x",
                Owner = user2
            };

            context.Addresses.Add(address);
            context.SaveChanges();
        }
    }
}