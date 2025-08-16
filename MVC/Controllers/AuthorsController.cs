using LibraryBookManagement.Data;
using LibraryBookManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


   
    namespace BookManagement.Controllers
        {
    
                public class AuthorsController : Controller
                {
                    private readonly LibraryContext _context;

                public AuthorsController(LibraryContext context)
                {
                    _context = context;
                }

                public IActionResult Index()
                    {
                        return View(_context.Authors.ToList());
                    }

                    public IActionResult Details(int id)
                    {
                        

                        var author = _context.Authors
                            .FirstOrDefault(m => m.Id == id);
                        if (author == null)
                        {
                            return NotFound();
                        }

                        return View(author);
                    }

                  
                    public IActionResult Create()
                    {
                 

                    return View();
                    }

                  
                    [HttpPost]
                    
                    public IActionResult Create(Author author)
                    {

                  
                    if (ModelState.IsValid)
                    {
                        _context.Add(author);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }

                    return View(author);

                }

                   
                    public IActionResult Edit(int id)
                    {

                        var author = _context.Authors.Find(id);
                        if (author == null)
                        {
                            return NotFound();
                        }
                        return View(author);
                    }
                    [HttpPost]
               
                    public IActionResult Edit(int id,  Author author)
                    {
                        if (id != author.Id)
                        {
                            return NotFound();
                        }

                    if (ModelState.IsValid)
                    {
                        _context.Update(author);
                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
                    return View(author);
                    }

                 
                    public IActionResult Delete(int? id)
                    {
                        if (id == null)
                        {
                            return NotFound();
                        }

                        var author = _context.Authors
                            .FirstOrDefault(m => m.Id == id);
                        if (author == null)
                        {
                            return NotFound();
                        }

                        return View(author);
                    }

                  
                    [HttpPost]
                   
                    public IActionResult DeleteConfirmed(int id)
                    {
                        var author = _context.Authors.Find(id);
                        if (author != null)
                        {
                            _context.Authors.Remove(author);
                            _context.SaveChanges();
                        }

                        return RedirectToAction(nameof(Index));
                    }

                  
                }
            }
        

