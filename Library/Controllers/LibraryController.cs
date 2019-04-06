using System;
using System.Collections.Generic;
using System.Linq;

using Library.Models;
using Library.Data;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new LibraryDb ())
            {
                var tasks = db.Books.ToList();
                return View(tasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string author, double price)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || price<1)
            {
                return RedirectToAction("Index");
            }
            using (var db = new LibraryDb())
            {
                Book book = new Book
                {
                    Title = title,
                    Author = author,
                    Price = price
                
                };

                db.Books.Add(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDb())
            {
                var books = db.Books.Find(id);

                return View(books);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {

            using (var db = new LibraryDb())
            {
                db.Books.Update(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDb())
            {
                var tasks = db.Books.Find(id);

                return View(tasks);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new LibraryDb())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}