// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApplication
{
    class Program
    {
        
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }

            public Book(string title, string author, string genre)
            {
                Title = title;
                Author = author;
                Genre = genre;
            }
        }

        static void Main(string[] args)
        {
            
            List<Book> library = new List<Book>
            {
                new Book("Savaş ve Barış", "Lev Tolstoy", "Roman"),
                new Book("1984", "George Orwell", "Distopya"),
                new Book("Suç ve Ceza", "Fyodor Dostoyevski", "Roman"),
                new Book("Dune", "Frank Herbert", "Bilim Kurgu"),
                new Book("Küçük Prens", "Antoine de Saint-Exupéry", "Masal")
            };

            Console.WriteLine("Kütüphane Uygulamasına Hoş Geldiniz!");

            while (true)
            {
                Console.WriteLine("\nAramak istediğiniz kitap adını, yazarını veya türünü yazınız (Çıkış için 'çıkış' yazın):");
                string searchQuery = Console.ReadLine();

                if (searchQuery.Equals("çıkış", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Uygulama sonlandırılıyor. İyi günler!");
                    break;
                }

                
                var searchResults = library.Where(book =>
                    book.Title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    book.Genre.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
                ).ToList();

                
                if (searchResults.Any())
                {
                    Console.WriteLine("\nArama Sonuçları:");
                    foreach (var book in searchResults)
                    {
                        Console.WriteLine($"Kitap: {book.Title}, Yazar: {book.Author}, Tür: {book.Genre}");
                    }
                }
                else
                {
                    Console.WriteLine("\nAradığınız kriterlere uygun kitap bulunamadı.");
                }
            }
        }
    }
}

