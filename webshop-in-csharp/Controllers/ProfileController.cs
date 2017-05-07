using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebshopInCsharp.Models;
using Microsoft.AspNetCore.Identity;
using WebshopInCsharp.Models.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebshopInCsharp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        private UserManager<User> _userManager;

        private IHostingEnvironment _environment;

        public ProfileController(ApplicationDbContext context, UserManager<User> userManager, IHostingEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }
        
        // GET: Profile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .SingleOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        [HttpGet]
        public IActionResult Search()
        {
            ProfileSearchViewModel vm = new ProfileSearchViewModel();
            vm.MinAge = 18;
            vm.MaxAge = 85;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Search(ProfileSearchViewModel vm)
        {
            List<ProfileSearchResultModel> result = new List<ProfileSearchResultModel>();
            if (ModelState.IsValid)
            {
                DateTime minDate = DateTime.Today.AddYears(-vm.MaxAge);
                DateTime maxDate = DateTime.Today.AddYears(-vm.MinAge);

                result = (from p in _context.Profiles
                          where p.Gender == vm.Gender
                          && p.Birthdate > minDate && p.Birthdate < maxDate
                          select new ProfileSearchResultModel
                          {
                              Description = p.Description,
                              Id = p.Id,
                              ProfilePicture = $"{p.User.Id}/{p.ProfilePicture}",
                              Gender = p.Gender,
                              DisplayName = p.DisplayName,
                              Age = calculateAge(p.Birthdate)
                          }
                          ).ToList();
            }
            return View("Result", result);
        }
        
        private int calculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit()
        {
            User currentUser = await _userManager.GetUserAsync(User);
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.Id == currentUser.ProfileId);
            return View(profile);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,DisplayName,Birthdate,Description,ProfilePicture,ProfilePictureFile ")] Profile profile, IFormFile ProfilePictureFile)
        {
            if (ModelState.IsValid)
            {
                User currentUser = await _userManager.GetUserAsync(User);

                if(ProfilePictureFile != null)
                {
                    string uploadPath = Path.Combine(_environment.WebRootPath, "uploads");
                    Directory.CreateDirectory(Path.Combine(uploadPath, currentUser.Id));

                    string filename = Path.GetFileName(ProfilePictureFile.FileName);

                    using (FileStream fs = new FileStream(Path.Combine(uploadPath, currentUser.Id, filename), FileMode.Create))
                    {
                        await ProfilePictureFile.CopyToAsync(fs);
                    }
                    profile.ProfilePicture = filename;
                }


                _context.Update(profile);
                await _context.SaveChangesAsync();
            }
            return View(profile);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .SingleOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profile = await _context.Profiles.SingleOrDefaultAsync(m => m.Id == id);
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
