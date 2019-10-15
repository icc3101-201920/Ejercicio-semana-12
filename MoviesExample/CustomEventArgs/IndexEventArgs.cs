using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesExample.CustomEventArgs
{
    public enum ButtonTypeClicked
    {
        movie,
        person,
        studio
    }

    public class IndexEventArgs :EventArgs
    {
        public ButtonTypeClicked ButtonType { get; set; }
        public string Filter { get; set; }
    }
}
