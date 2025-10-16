using LibraryManager.Models;

namespace LibraryManager.DatabaseImitation;

public class LibraryDbContext
{
    public LibraryDbContext()
    {
        AuthorInitialization();
        BookInitialization();
    }
    
    public List<Author> Authors { get; set; }
    public List<Book> Books { get; set; }

    private void AuthorInitialization()
    {
        Authors = new List<Author>
        {
            new Author { Id = 1, Name = "Лев Толстой", DateOfBirth = new DateTime(1828, 9, 9) },
            new Author { Id = 2, Name = "Фёдор Достоевский", DateOfBirth = new DateTime(1821, 11, 11) },
            new Author { Id = 3, Name = "Александр Пушкин", DateOfBirth = new DateTime(1799, 6, 6) },
            new Author { Id = 4, Name = "Николай Гоголь", DateOfBirth = new DateTime(1809, 3, 31) },
            new Author { Id = 5, Name = "J.K. Rowling", DateOfBirth = new DateTime(1965, 7, 31) }
        };
    }

    private void BookInitialization()
    {
        Books = new List<Book>
            {
                // Лев Толстой
                new Book { Id = 1, Title = "Война и мир", PublishedYear = 1869, AuthorId = 1 },
                new Book { Id = 2, Title = "Анна Каренина", PublishedYear = 1877, AuthorId = 1 },
                new Book { Id = 3, Title = "Воскресение", PublishedYear = 1899, AuthorId = 1 },
                new Book { Id = 4, Title = "Детство", PublishedYear = 1852, AuthorId = 1 },
                new Book { Id = 5, Title = "Отрочество", PublishedYear = 1854, AuthorId = 1 },

                // Фёдор Достоевский
                new Book { Id = 6, Title = "Преступление и наказание", PublishedYear = 1866, AuthorId = 2 },
                new Book { Id = 7, Title = "Идиот", PublishedYear = 1869, AuthorId = 2 },
                new Book { Id = 8, Title = "Братья Карамазовы", PublishedYear = 1880, AuthorId = 2 },
                new Book { Id = 9, Title = "Бедные люди", PublishedYear = 1846, AuthorId = 2 },
                new Book { Id = 10, Title = "Подросток", PublishedYear = 1875, AuthorId = 2 },

                // Александр Пушкин
                new Book { Id = 11, Title = "Евгений Онегин", PublishedYear = 1833, AuthorId = 3 },
                new Book { Id = 12, Title = "Капитанская дочка", PublishedYear = 1836, AuthorId = 3 },
                new Book { Id = 13, Title = "Борис Годунов", PublishedYear = 1825, AuthorId = 3 },
                new Book { Id = 14, Title = "Повести Белкина", PublishedYear = 1831, AuthorId = 3 },
                new Book { Id = 15, Title = "Руслан и Людмила", PublishedYear = 1820, AuthorId = 3 },

                // Николай Гоголь
                new Book { Id = 16, Title = "Мёртвые души", PublishedYear = 1842, AuthorId = 4 },
                new Book { Id = 17, Title = "Ревизор", PublishedYear = 1836, AuthorId = 4 },
                new Book { Id = 18, Title = "Тарас Бульба", PublishedYear = 1835, AuthorId = 4 },
                new Book { Id = 19, Title = "Вечера на хуторе близ Диканьки", PublishedYear = 1831, AuthorId = 4 },
                new Book { Id = 20, Title = "Шинель", PublishedYear = 1842, AuthorId = 4 },

                // J.K. Rowling
                new Book { Id = 21, Title = "Harry Potter and the Philosopher's Stone", PublishedYear = 1997, AuthorId = 5 },
                new Book { Id = 22, Title = "Harry Potter and the Chamber of Secrets", PublishedYear = 1998, AuthorId = 5 },
                new Book { Id = 23, Title = "Harry Potter and the Prisoner of Azkaban", PublishedYear = 1999, AuthorId = 5 },
                new Book { Id = 24, Title = "Harry Potter and the Goblet of Fire", PublishedYear = 2000, AuthorId = 5 },
                new Book { Id = 25, Title = "Harry Potter and the Order of the Phoenix", PublishedYear = 2003, AuthorId = 5 }
            };
    }
}