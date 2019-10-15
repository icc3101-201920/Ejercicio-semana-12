using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesExample.CustomEventArgs
{
    public class ProfileEventArgs:EventArgs
    {
        public object SelectedItem { get; set; }
    }
}
