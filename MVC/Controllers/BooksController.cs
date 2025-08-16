using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryBookManagement.Models;
using System.Linq;
using LibraryBookManagement.Data;

namespace BookAuthorManager.Controllers
{
  
        public class BooksController : Controller
        {
            private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }




        public IActionResult Index()
            {
                var applicationDbContext = _context.Books.Include(b => b.Author);
                return View(applicationDbContext.ToList());
            }

        
            public IActionResult Details(int id)
            {
                

                var book = _context.Books
                    .Include(b => b.Author)
                    .FirstOrDefault(m => m.Id == id);
                if (book == null)
                {
                    return NotFound();
                }

                return View(book);
            }

        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            return View();
        }

        [HttpPost]
        
        public IActionResult Create( Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }



        public IActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var book = _context.Books.Find(id);
                if (book == null)
                {
                    return NotFound();
                }
                ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
                return View(book);
            }

         
            [HttpPost]
           
            public IActionResult Edit(int id, Book book)
            {
                if (id != book.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                        _context.Update(book);
                        _context.SaveChanges();
                   
                    return RedirectToAction(nameof(Index));
                }
                ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
                return View(book);
            }

            public IActionResult Delete(int id)
            {
                

                var book = _context.Books
                    .Include(b => b.Author)
                    .FirstOrDefault(m => m.Id == id);
                if (book == null)
                {
                    return NotFound();
                }

                return View(book);
            }

           
            [HttpPost]
          
            public IActionResult DeleteConfirmed(int id)
            {
                var book = _context.Books.Find(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }

            
        }
    }
