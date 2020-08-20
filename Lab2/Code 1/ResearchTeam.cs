using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLabs
{
  class ResearchTeam : Team, INameAndCopy, IEnumerable
  {
    private string _Theme;
    private string _Organization;
    private TimeFrame _TimeFrame;
    private List<Person> _Members;
    private List<Paper> _Publications;

    public ResearchTeam(string name, int number, string theme, string org, int num, TimeFrame tf)
    : base(name, number)
    {
      _Theme = theme;
      _Organization = org;
      _Number = num;
      _TimeFrame = tf;
      _Members = new List<Person>();
      _Publications = new List<Paper>();
    }

    public ResearchTeam()
    {
      _Theme = "МояТема";
      _Organization = "МояОргнзц";
      _Number = 1;
      _TimeFrame = TimeFrame.Long;
      _Members = new List<Person>();
      _Publications = new List<Paper>();
    }

    public string Theme
    {
      get => _Theme;
      set => _Theme = value;
    }

    public string Organization
    {
      get => _Organization;
      set => _Organization = value;
    }

    public TimeFrame TimeFrame
    {
      get => _TimeFrame;
      set => _TimeFrame = value;
    }

    public List<Person> Members
    {
      get => _Members;
      set => _Members = value;
    }

    public Team Team
    {
      get => new Team(base.Name, base.Number);
      set
      {
        base.Name = value.Name;
        base.Number = value.Number;
      }
    }

    public List<Paper> Papers => _Publications;

    public Paper LastPaper =>
      _Publications.Find(l => l.Date == _Publications.Max(p => p.Date));

    public bool this[TimeFrame timeFrame]
    {
      get => timeFrame == _TimeFrame;
    }

    public void AddPapers(params Paper[] papers) =>
      Papers.AddRange(papers);

    public void AddMembers(params Person[] members) =>
      _Members.AddRange(members);

    public string ToShortString() =>
      $"Тема: {_Theme}\tОрганизация: {_Organization}\t" +
      $"{base.ToString()}\tПромежуток: {_TimeFrame}";

    public override string ToString() =>
      $"{ToShortString()}\n" +
      $"Публикации:\n{string.Join("\n", _Publications)}\n" +
      $"Члены:\n{string.Join("\n", _Members)}";

    public override object Clone() =>
      new ResearchTeam
      {
        Team = (Team)base.Clone(),
        _Theme = this._Theme,
        _Members = new List<Person>(this._Members),
        _Organization = this._Organization,
        _Publications = new List<Paper>(this._Publications),
        _TimeFrame = this._TimeFrame,
      };

    //нет публикаций
    public IEnumerable AuthorsWithoutPapers()
    {
      foreach (var person in _Members)
      {
        if (!_Publications.Exists(pub => pub.Author == person))
          yield return person;
      }
    }

    public IEnumerable PublicationForYear(int year)
    {
      foreach(var paper in _Publications)
      {
        if (DateTime.Today.Year - paper.Date.Year < year)
          yield return paper;
      }
    }

    // дополнительное задание
    #region
    // авторы c публикациями
    public IEnumerator GetEnumerator() =>
       new ResearchTeamEnumerator(_Publications);

    public IEnumerable AuthorsMoreThen1Paper()
    {
      foreach (var author in _Members)
        if (_Publications.Count(p => p.Author == author) > 1)
          yield return author;
    }

    public IEnumerable PapersForLastYear()
    {
      foreach (var paper in _Publications)
        if (DateTime.Now.Subtract(paper.Date).Days < 365)
          yield return paper;
    }
    #endregion
  }
}
