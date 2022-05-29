using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tools
{
   public class DbContextSingleton
    {
        private DbContextSingleton()
        {
                
        }
        private static ProjeContext _context;
        public static ProjeContext Context
        {
            get 
            {
                if (_context==null)
                {
                    _context = new ProjeContext();
                }
                return _context;
            }
        }


    }
}
