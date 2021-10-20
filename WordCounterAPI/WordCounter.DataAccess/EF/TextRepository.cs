using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WordCounter.DataAccess.EF.Context;
using WordCounter.DataAccess.Repositories;

namespace WordCounter.DataAccess.EF
{
    public class TextRepository : ITextRepository
    {
        private WordCounterContext _context = new WordCounterContext();
        public void Add(Models.Text entry)
        {
            throw new NotImplementedException(); 
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Models.Text> Find(Expression<Func<Models.Text, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Models.Text Get(int id)
        {
            throw new NotImplementedException(); 
        }

        public IEnumerable<Models.Text> GetAll()
        {
            IQueryable<Models.Text> query = _context.Texts.AsNoTracking();
            return query; 
        }

        public void Remove(Models.Text entry)
        {
            throw new NotImplementedException();
        }
    }
}
