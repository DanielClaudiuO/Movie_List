using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        private readonly WebApplication1Context _context;

        static List<Book> books = new List<Book>()
        {
            new Book(){ID=Guid.NewGuid(), Name="Permanent Record", Author="Edward Snowden", firstEdition= 2019},
            new Book(){ID=Guid.NewGuid(), Name="Mere Christianity", Author="C.S.Lewis", firstEdition=1952},
            new Book(){ID=Guid.NewGuid(), Name="The Fellowship of the Ring", Author="J.R.R. Tolkien", firstEdition=1954}
        };
        public BooksController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Books
        public IActionResult Index()
        {
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = books.FirstOrDefault(x => x.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Book book)
        {
            if (ModelState.IsValid)
            {
                book.ID = Guid.NewGuid();
                books.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = books.FirstOrDefault(x => x.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ID,Name,Author,firstEdition")] Book book)
        {
            if (id != book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentBook = books.FirstOrDefault(x => x.ID == id);
                currentBook.Name = book.Name;
                currentBook.Author = book.Author;
                currentBook.firstEdition = book.firstEdition;

                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = books.FirstOrDefault(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var book = books.FirstOrDefault(m => m.ID == id);
            books.Remove(book);
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(Guid id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}
