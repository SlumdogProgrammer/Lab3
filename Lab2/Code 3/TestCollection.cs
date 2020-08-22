using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs
{
  delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
  class TestCollection<TKey, TValue>
  {
    private List<TKey> _TKeys;
    private List<string> _Strings;
    private Dictionary<TKey, TValue> _TKeysTValue;
    private Dictionary<string, TValue> _StringsTValue;
    private GenerateElement<TKey, TValue> _GenElTKeyTValue;

    public TestCollection(int capacity, GenerateElement<TKey, TValue> func)
    {
      _TKeys = new List<TKey>(capacity);
      _Strings = new List<string>(capacity);
      _TKeysTValue = new Dictionary<TKey, TValue>(capacity);
      _GenElTKeyTValue = func;
    }

    public static KeyValuePair<int, TValue> Generator(int num) =>
      new KeyValuePair<int, TValue>(num, default);
    
      
  }
}
