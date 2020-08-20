using System;

namespace CSharpLabs
{
  class Person : INameAndCopy, IEquatable<Person>
  {
    private string _Name;
    private string _Surname;
    DateTime _Birth;

    public Person(string name, string surname, DateTime birth)
    {
      _Name = name;
      _Surname = surname;
      _Birth = birth;
    }

    public Person()
    {
      _Name = "Иван";
      _Surname = "Болван";
      _Birth = new DateTime(2020, 8, 9);
    }

    public string Name
    {
      get => _Name;
      set => _Name = value;
    }

    public string Surname
    {
      get => _Surname;
      set => _Surname = value;
    }
        
    public DateTime Birth
    {
      get => _Birth;
      set => _Birth = value;
    }

    public int ChangeYear
    {
      get => _Birth.Year;
      set => _Birth.AddYears(-_Birth.Year + value);
    }

    public virtual string ToShortString() =>
      $"Имя: {_Name}\t Фамилия: {_Surname}";

    public override string ToString() =>
      $"{ToShortString()}\t" +
      $"ДР: {_Birth.ToShortDateString()}";

    public bool Equals(Person other)
    {
      if (ReferenceEquals(this, null))
        return false;

      if (ReferenceEquals(other, null))
        return false;

      if (ReferenceEquals(this, other))
        return true;

      if (GetType() != other.GetType())
        return false;

      return other.Surname == _Surname &&
        other.Name == _Name && other.Birth == _Birth;
    }

    public override bool Equals(object obj) =>
      Equals(obj as Person);

    public override int GetHashCode() =>
      _Name.GetHashCode() + _Surname.GetHashCode() + _Birth.GetHashCode();

    public static bool operator ==(Person p1, Person p2) =>
      p1.Equals(p2);

    public static bool operator !=(Person p1, Person p2) =>
      !(p1 == p2);

    public object Clone() =>
      new Person
      { _Name = this._Name, _Surname = this._Surname, _Birth = this._Birth };

  }
}
