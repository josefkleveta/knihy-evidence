using Knihy.Models;

namespace Knihy.Data {
    public class AppDbInitializer {
        public static void Seed(IApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //context.Database.EnsureCreated();

                //if (!context.Publishers.Any()) {
//                    context.Publishers.AddRange(new List<Publisher>()
//                        {
//                        new Publisher() {
//                            Name = "Jmeno nakladatelstvi",
//                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr2BdfkHLSmN8xPgke224Z1J5r-08EX20fow&s",
//                            Description = "Popis prvniho nakladatelstvi"
//                        },
//                        new Publisher() {
//                            Name = "Jmeno nakladatelstvi",
//                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr2BdfkHLSmN8xPgke224Z1J5r-08EX20fow&s",
//                            Description = "Popis prvniho nakladatelstvi"
//                        },
//                        new Publisher() {
//                            Name = "Jmeno nakladatelstvi",
//                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr2BdfkHLSmN8xPgke224Z1J5r-08EX20fow&s",
//                            Description = "Popis prvniho nakladatelstvi"
//                        },
//                        new Publisher() {
//                            Name = "Jmeno nakladatelstvi",
//                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr2BdfkHLSmN8xPgke224Z1J5r-08EX20fow&s",
//                            Description = "Popis prvniho nakladatelstvi"
//                        },
//                        new Publisher() {
//                            Name = "Jmeno nakladatelstvi",
//                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr2BdfkHLSmN8xPgke224Z1J5r-08EX20fow&s",
//                            Description = "Popis prvniho nakladatelstvi"
//                        },
//                    });
//                    context.SaveChanges();
//                }
//                if (!context.Writers.Any()) {
//                    context.Writers.AddRange(new List<Writer>()
//    {
//                        new Writer() {
//                            FullName = "Miroslav Zamboch",
//                            Bio = "Miroslav Žamboch vystudoval Fakultu jadernou a fyzikálně inženýrskou ČVUT v Praze a nyní pracuje v ÚJV Řež, a. s., (bývalý Ústav jaderného výzkumu v Řeži u Prahy). ",
//                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg/250px-Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg",
//                        },
//                        new Writer() {
//                            FullName = "Miroslav Zamboch",
//                            Bio = "Miroslav Žamboch vystudoval Fakultu jadernou a fyzikálně inženýrskou ČVUT v Praze a nyní pracuje v ÚJV Řež, a. s., (bývalý Ústav jaderného výzkumu v Řeži u Prahy). ",
//                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg/250px-Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg",
//                        },
//                        new Writer() {
//                            FullName = "Miroslav Zamboch",
//                            Bio = "Miroslav Žamboch vystudoval Fakultu jadernou a fyzikálně inženýrskou ČVUT v Praze a nyní pracuje v ÚJV Řež, a. s., (bývalý Ústav jaderného výzkumu v Řeži u Prahy). ",
//                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg/250px-Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg",
//                        },
//                        new Writer() {
//                            FullName = "Miroslav Zamboch",
//                            Bio = "Miroslav Žamboch vystudoval Fakultu jadernou a fyzikálně inženýrskou ČVUT v Praze a nyní pracuje v ÚJV Řež, a. s., (bývalý Ústav jaderného výzkumu v Řeži u Prahy). ",
//                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg/250px-Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg",
//                        },
//                        new Writer() {
//                            FullName = "Miroslav Zamboch",
//                            Bio = "Miroslav Žamboch vystudoval Fakultu jadernou a fyzikálně inženýrskou ČVUT v Praze a nyní pracuje v ÚJV Řež, a. s., (bývalý Ústav jaderného výzkumu v Řeži u Prahy). ",
//                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg/250px-Auto%C5%99i_Agenta_JFK_%28Miroslav_%C5%BDamboch%29_na_Sv%C4%9Btu_knihy_2016_%28cropped%29.jpg",
//                        },
//                    });
//                    context.SaveChanges();
//                }
//                if (!context.Editors.Any()) {
//                    context.Editors.AddRange(new List<Editor>()
//{
//                        new Editor() {
//                            FullName = "Jmeno editora",
//                            Bio = "Bio prvniho editora",
//                            ProfilePictureURL = "https://storage.prodej-knih.cz/images/medium/57ac84684c6333384910355094ac28e6.jpg",
//                        },
//                        new Editor() {
//                            FullName = "Jmeno editora",
//                            Bio = "Bio prvniho editora",
//                            ProfilePictureURL = "https://storage.prodej-knih.cz/images/medium/57ac84684c6333384910355094ac28e6.jpg",
//                        },
//                        new Editor() {
//                            FullName = "Jmeno editora",
//                            Bio = "Bio prvniho editora",
//                            ProfilePictureURL = "https://storage.prodej-knih.cz/images/medium/57ac84684c6333384910355094ac28e6.jpg",
//                        },
//                        new Editor() {
//                            FullName = "Jmeno editora",
//                            Bio = "Bio prvniho editora",
//                            ProfilePictureURL = "https://storage.prodej-knih.cz/images/medium/57ac84684c6333384910355094ac28e6.jpg",
//                        },

//                    });
//                    context.SaveChanges();
//                }
//                if (!context.Books.Any()) {
//                    context.Books.AddRange(new List<Book>()
//{
//                        new Book() {
//                            Name = "Mrvti",
//                            Description = "Popis knihy",
//                            View = "odkaz",
//                            ImageURL = "https://mrtns.sk/tovar/_l/2189/l2189317.jpg?v=17198928802",
//                            BuyDate = DateTime.Now.AddDays(-10),
//                            FinishedDate = DateTime.Now.AddDays(1),
//                            PublisherId = 1,
//                            EditorId = 1,
//                            BookCategory = Enums.BookCategory.Fiction,
//                        },
//                        new Book() {
//                            Name = "Mrvti",
//                            Description = "Popis knihy",
//                            View = "odkaz",
//                            ImageURL = "https://mrtns.sk/tovar/_l/2189/l2189317.jpg?v=17198928802",
//                            BuyDate = DateTime.Now.AddDays(-10),
//                            FinishedDate = DateTime.Now.AddDays(1),
//                            PublisherId = 1,
//                            EditorId = 1,
//                            BookCategory = Enums.BookCategory.Fiction,
//                        },
//                        new Book() {
//                            Name = "Mrvti",
//                            Description = "Popis knihy",
//                            View = "odkaz",
//                            ImageURL = "https://mrtns.sk/tovar/_l/2189/l2189317.jpg?v=17198928802",
//                            BuyDate = DateTime.Now.AddDays(-10),
//                            FinishedDate = DateTime.Now.AddDays(1),
//                            PublisherId = 1,
//                            EditorId = 1,
//                            BookCategory = Enums.BookCategory.Fiction,
//                        },
//                        new Book() {
//                            Name = "Mrvti",
//                            Description = "Popis knihy",
//                            View = "odkaz",
//                            ImageURL = "https://mrtns.sk/tovar/_l/2189/l2189317.jpg?v=17198928802",
//                            BuyDate = DateTime.Now.AddDays(-10),
//                            FinishedDate = DateTime.Now.AddDays(1),
//                            PublisherId = 1,
//                            EditorId = 1,
//                            BookCategory = Enums.BookCategory.Fiction,
//                        },
//                        new Book() {
//                            Name = "Mrvti",
//                            Description = "Popis knihy",
//                            View = "odkaz",
//                            ImageURL = "https://mrtns.sk/tovar/_l/2189/l2189317.jpg?v=17198928802",
//                            BuyDate = DateTime.Now.AddDays(-10),
//                            FinishedDate = DateTime.Now.AddDays(1),
//                            PublisherId = 1,
//                            EditorId = 1,
//                            BookCategory = Enums.BookCategory.Fiction,
//                        },

//                    });
//                    context.SaveChanges();
                //}
                //if (!context.Writer_Books.Any()) {
                //    context.Writer_Books.AddRange(new List<Writer_Book>() {
                //    new Writer_Book(){
                //        BookId = 3,
                //        WriterId = 1,
                //    },
                //    new Writer_Book(){
                //        BookId = 3,
                //        WriterId = 1,
                //    },
                //    new Writer_Book(){
                //        BookId = 3,
                //        WriterId = 1,
                //    },
                //    new Writer_Book(){
                //        BookId = 3,
                //        WriterId = 1,
                //    },
                //    new Writer_Book(){
                //        BookId = 3,
                //        WriterId = 1,
                //    },
                //    });
                //}

            }
        }
    }
}
