using System;
using System.Diagnostics;

namespace CSharpLabs
{
  class Program
  {
    static void Main(string[] args)
    {
      #region Лр. 2
      // 1
      Team team1 = new Team();
      Team team2 = new Team();
      Console.WriteLine("Равенство ссылок на объекты: " + ReferenceEquals(team1, team2));
      Console.WriteLine("Равенство объектов: " + (team1 == team2));
      Console.WriteLine("Hash team1 " + team1.GetHashCode() + " Hash team2 " + team2.GetHashCode());
      Console.WriteLine();
      // 2
      try { team1.Number = -1; }
      catch (Exception e) { Console.WriteLine(e.Message); }
      Console.WriteLine();
      // 3
      ResearchTeam researchTeam = new ResearchTeam();
      Person person1 = new Person("Petr", "Petrov", new DateTime(2000, 12, 2));
      Person person2 = new Person("Автор", "Без Публикаций", new DateTime(1996, 4, 3));
      researchTeam.AddMembers(new Person(), person1, person2);
      researchTeam.AddPapers(new Paper(), new Paper("SAPR", person1, new DateTime(2020, 1, 1)),
        new Paper("PM", person1, new DateTime(2010, 1, 1)));
      // 4
      Console.WriteLine(researchTeam.Team);
      // 5
      var researchTeamCopy = researchTeam.Clone() as ResearchTeam;
      researchTeam.Organization = "OZON";
      Console.WriteLine("RT: " + researchTeam);
      Console.WriteLine("RTC " + researchTeamCopy);
      Console.WriteLine();
      // 6
      foreach (var mem in researchTeam.AuthorsWithoutPapers())
        Console.WriteLine(mem);
      Console.WriteLine();
      // 7
      foreach (var pub in researchTeam.PublicationForYear(2))
        Console.WriteLine(pub);
      Console.WriteLine();
      // 8
      foreach (var mem in researchTeam)
        Console.WriteLine(mem);
      Console.WriteLine();
      // 9
      foreach (var pub in researchTeam.AuthorsMoreThen1Paper())
        Console.WriteLine(pub);
      Console.WriteLine();
      // 10
      foreach (var pub in researchTeam.PapersForLastYear())
        Console.WriteLine(pub);
      #endregion

    }
  }
}
