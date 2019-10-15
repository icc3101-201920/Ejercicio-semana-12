using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesExample.CustomEventArgs
{
    public class SearchEventArgs:EventArgs
    {
        public string SearchText { get; set; }
    }
}
