using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs
{
  class Team : INameAndCopy
  {
    protected string _Name;
    protected int _Number;

    public Team(string name, int number)
    {
      _Name = name;
      _Number = number;
    }

    public Team()
    {
      _Name = "ОИМ";
      _Number = 1;
    }

    public string Name
    {
      get => _Name;
      set => _Name = value;
    }

    public int Number
    {
      get => _Number;
      set
      {
        if (value > 0)
          _Number = value;
        else
          throw new ArgumentOutOfRangeException("Значение должно быть больше нуля!");
      }
    }

    public override string ToString() =>
      $"Название команды: {_Name}\tРегистрационный номер: {_Number}";
    
    public override int GetHashCode() =>
      _Number.GetHashCode() + _Name.GetHashCode();
    
    public override bool Equals(object obj)
    {
      Team team = obj as Team;
      return _Name == team._Name && _Number == team._Number;
    }

    public static bool operator ==(Team team1, Team team2) =>
      team1.Equals(team2);

    public static bool operator !=(Team team1, Team team2) =>
      !(team1 == team2);

    public virtual object Clone() =>
      new Team
      { _Name = this._Name, _Number = this._Number };
   
  }
}
