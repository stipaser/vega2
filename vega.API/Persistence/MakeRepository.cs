﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.API.Core;
using vega.API.Core.Models;

namespace vega.API.Persistence
{
    public class MakeRepository : IMakeRepository
    {
        private readonly VegaDbContext _context;

        public MakeRepository(VegaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await _context.Makes
                .Include(x => x.Models)
                .ToListAsync();
        }

        public void Add(Make make)
        {
            _context.Add(make);
        }

        public async Task<Make> GetMakeById(int makeId)
        {
            return await  _context.Makes
                    .Include(x => x.Models)
                    .SingleOrDefaultAsync( x => x.Id == makeId);
        }
    }
}
