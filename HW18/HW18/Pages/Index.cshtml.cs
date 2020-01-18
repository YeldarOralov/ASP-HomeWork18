using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HW18.Data;
using HW18.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HW18.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public List<Doctor> Doctors { get; set; }

        [BindProperty]
        public Doctor CurrentDoctor { get; set; }
        public void OnGet()
        {
            Doctors = _context.Doctors.ToList();
        }

        public ActionResult OnPost()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user is null)
                return NotFound();


            _context.MedicanCertificates.Add(new MedicalReport
            {
                Doctor = this.CurrentDoctor,
                Description = Description,
                Patient = user
            });
            _context.SaveChanges();

            return Redirect("Ok");
        }

    }
}
