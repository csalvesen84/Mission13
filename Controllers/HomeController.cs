using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {

        private BowlersDbContext _context { get; set; }
        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.ToList();

            List<Bowler> cont = _context.Bowlers.ToList();
            return View(cont);
        }

        public IActionResult Team(int TeamId)
        {

            var Team = _context.Teams.Single(x => x.TeamId == TeamId);
            ViewBag.TeamName = Team.TeamName;

            List<Team> teams = _context.Teams.ToList();

            List<Bowler> cont = _context.Bowlers.Where(x => x.TeamId == TeamId).ToList();
            return View(cont);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = _context.Teams.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Bowler submission)
        {
            ViewBag.Teams = _context.Teams.ToList();

            if (ModelState.IsValid)
            {
                _context.Add(submission);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = _context.Teams.ToList();

            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("Add", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler submission)
        {
            ViewBag.Teams = _context.Teams.ToList();

            if (ModelState.IsValid)
            {
                _context.Bowlers.Update(submission);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler bowler)
        {
            _context.Bowlers.Remove(bowler);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
