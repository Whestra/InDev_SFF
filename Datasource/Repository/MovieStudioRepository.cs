﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SFF.Datasource.Model;
using SFF.Datasource.Context;


namespace SFF.Datasource.Repository
{
    public class MovieStudioRepository : IRepository<MovieStudio>
    {
        readonly MovieStudioContext _context;

        public MovieStudioRepository(MovieStudioContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieStudio> List
        {
            get
            {
                return _context.MovieStudios;
            }
        }
        public void Add(MovieStudio movie)
        {
            _context.MovieStudios.Add(movie);
            _context.SaveChanges();
        }

        public void Delete(MovieStudio movie)
        {
            _context.MovieStudios.Remove(movie);
            _context.SaveChanges();
        }

        public void Update(MovieStudio movie)
        {
            _context.Entry(movie).State =
               EntityState.Modified;
            _context.SaveChanges();
        }

        public MovieStudio FindById(int id)
        {
            var results =
                (from m in _context.MovieStudios where m.Id == id select m)
                .FirstOrDefault();
            return results;

        }

    }
}