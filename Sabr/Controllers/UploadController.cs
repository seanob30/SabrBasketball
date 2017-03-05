using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using Microsoft.AspNet.Identity;
using Sabr.Models;
using Sabr.ViewModels;

namespace Sabr.Controllers
{
    public class UploadController : Controller
    {
        private ApplicationDbContext _context;
        public UploadController()
        {
           _context = new ApplicationDbContext(); 
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase uploadfile)
        {
            if (ModelState.IsValid)
            {
                if (uploadfile != null && uploadfile.ContentLength > 0)
                {
                    Stream stream = uploadfile.InputStream;
                    List<PerGameStatLine> temp = new List<PerGameStatLine>();
                    using (StreamReader readFile = new StreamReader(stream, Encoding.UTF8))
                    {
                        string line;
                        string[] row;
                        readFile.ReadLine();
                        while ((line = readFile.ReadLine()) != null)
                        {
                            row = line.Split(',');

                            PerGameStatLine s = new PerGameStatLine();

                            s.Player = row[0];
                            s.GamesPlayed = row[1];
                            s.GamesStarted = row[2];
                            s.MinutesPlayed = row[3];
                            s.FieldGoalsMade = row[4];
                            s.FieldGoalsAttemped = row[5];
                            s.FieldGoalPercentage = row[6];
                            s.ThreePointersMade = row[7];
                            s.ThreePointersAttempted = row[8];
                            s.ThreePointPercentage = row[9];
                            s.TwoPointersMade = row[10];
                            s.TwoPointersAttempted = row[11];
                            s.TwoPointPercentage = row[12];
                            s.EffectiveFieldGoalPercentage = row[13];
                            s.FreeThrowsMade = row[14];
                            s.FreeThrowsAttempted = row[15];
                            s.FreeThrowPercentage = row[16];
                            s.OffensiveRebounds = row[17];
                            s.DefensiveRebounds = row[18];
                            s.TotalRebounds = row[19];
                            s.Assists = row[20];
                            s.Steals = row[21];
                            s.Blocks = row[22];
                            s.Turnovers = row[23];
                            s.PersonalFouls = row[24];
                            s.Points = row[25];
                            
                           temp.Add(s);
                        }
                        readFile.Close();
                    }
                    foreach (var statLine in temp)
                    {
                        _context.PerGameStatLines.Add(statLine);
                        _context.SaveChanges();
                    }
                    return View("Success");
                }
            }

            return View("Index");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}