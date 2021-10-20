using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WordCounter.DataAccess.EF.Models;

namespace WordCounter.DataAccess.Repositories
{
    public interface ITextRepository : IDisposable
    {
        Text Get(int id);
        IEnumerable<Text> GetAll();
        IEnumerable<Text> Find(Expression<Func<Text, bool>> expression);
        void Add(Text entry);
        void Remove(Text entry);
    }
}
