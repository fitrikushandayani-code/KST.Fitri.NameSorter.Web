using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KST.Fitri.NameSorter.Library
{
    public class csSorts
    {
        public static List<string> AscendingAlpphabetical(List<string> data)
        {
            return data.OrderBy(x => x.Split(' ').Last()).ThenBy(x => x.Split(' ').First()).ThenBy(x => x.Length).ToList();
        }
    }
}
