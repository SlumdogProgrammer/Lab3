using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs
{
  class ResearchTeamEnumerator : IEnumerator
  {
    private List<Person> _Members = new List<Person>();
    private int position = -1;

    public ResearchTeamEnumerator(List<Paper> publications)
    {
      Person[] people = new Person[publications.Count];
      for (int i = 0; i < publications.Count; i++)
        people[i] = publications[i].Author;
      _Members = people.Distinct().ToList();
    }
    
    public object Current
    {
      get
      {
        if (position == -1 || position >= _Members.Count)
          throw new InvalidOperationException();
        return _Members[position];
      }
    }

    public bool MoveNext()
    {
      if (position < _Members.Count - 1)
      {
        position++;
        return true;
      }
      return false;
    }

    public void Reset() =>
      position = -1;
    
  }
}
