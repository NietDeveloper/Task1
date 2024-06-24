﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Task1.Data;
using Task1.Models;

namespace Task1.Controllers
{
    public class CategoryController : Controller
    {
        private AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Category.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = _context.Category.First(x=> x.Id == id);
            return View(category); 
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = _context.Category.First(x=>x.Id == id);
            _context.Category.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
