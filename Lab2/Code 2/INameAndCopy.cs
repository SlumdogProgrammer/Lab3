using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs
{
  interface INameAndCopy : ICloneable
  {
    string Name { get; set; }
  }
}
