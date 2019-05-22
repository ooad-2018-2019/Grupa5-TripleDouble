﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BestDeal.Models;

namespace BestDeal.Controllers
{
    public class DetailsModel : PageModel
    {
        private readonly BestDeal.Models.BestDealContext _context;

        public DetailsModel(BestDeal.Models.BestDealContext context)
        {
            _context = context;
        }

        public Artikal Artikal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artikal = await _context.Artikal.FirstOrDefaultAsync(m => m.IdArtikla == id);

            if (Artikal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}