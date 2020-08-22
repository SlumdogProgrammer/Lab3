using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs
{
  class PaperComparer : IComparer<Paper>
  {
    public int Compare(Paper x, Paper y) =>
      x.Author.Surname.CompareTo(y.Author.Surname);
    
  }
}
