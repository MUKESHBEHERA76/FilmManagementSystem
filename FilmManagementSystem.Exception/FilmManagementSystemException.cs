using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagementSystem.Exception
{
    public class FilmManagementSystemException:ApplicationException
    {
        public FilmManagementSystemException(string str) : base(str)
        {

        }
    }
}
