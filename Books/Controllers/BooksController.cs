using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Books.Models;
using Books.ViewModels;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksContext _context;

        public BooksController(BooksContext context)
        {
            _context = context;    
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _context.Book.Include(b => b.Author).ToListAsync();
            //for(int i = 0; i < books.Count; i++)
            //{
            //    books[i].Author = _context.Author.Where(r => r.ID == books[i].AuthorRefId).Single();
            //}
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.Include(b => b.Author).SingleOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            //book.Author = _context.Author.Where(r => r.ID == book.AuthorRefId).SingleOrDefault();
            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            Two two = new Two();
            two.Authors = _context.Author.ToList();
            two.Book = new Book();
            return View(two);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Two twoR)
        {            
            if (ModelState.IsValid)
            {
                twoR.Book.Author = _context.Author.Where(r => r.ID == twoR.Book.AuthorRefId).SingleOrDefault();
                _context.Add(twoR.Book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            Two two = new Two();
            two.Authors = _context.Author.ToList();
            two.Book = twoR.Book;
            return View(two);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.Include(b => b.Author).SingleOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            Two two = new Two();
            two.Authors = _context.Author.ToList();
            two.Book = book;
            return View(two);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Two twoR)
        {
            if (id != twoR.Book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    twoR.Book.Author = _context.Author.Where(r => r.ID == twoR.Book.AuthorRefId).SingleOrDefault();
                    _context.Update(twoR.Book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(twoR.Book.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            Two two = new Two();
            two.Authors = _context.Author.ToList();
            two.Book = twoR.Book;
            return View(two);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .SingleOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.SingleOrDefaultAsync(m => m.ID == id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }

    public class Two
    {
        public List<Author> Authors { get; set; }
        public Book Book { get; set; }
    }
}
