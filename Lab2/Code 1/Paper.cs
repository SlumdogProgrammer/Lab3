using System;

namespace CSharpLabs
{
  class Paper : IComparable,IComparable<Paper>
  {
    public string Title { get; set; }
    public Person Author { get; set; }
    public DateTime Date { get; set; }

    public Paper(string title, Person author, DateTime date)
    {
      Title = title;
      Author = author;
      Date = date;
    }

    public Paper()
    {
      Title = "МояПубликация";
      Author = new Person();
      Date = new DateTime();
    }

    public override string ToString() =>
      $"Название: {Title}\t Автор: {Author}\t" +
      $"Дата: {Date.ToShortDateString()}";

    public int CompareTo(Paper other) =>
      Title.CompareTo(other.Title);


    public int CompareTo(object obj) =>
      Date.CompareTo((obj as Paper).Date);
   
  }
}
