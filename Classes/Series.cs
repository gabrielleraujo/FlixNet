using System;

namespace FlixNet
{
  public class Series : BaseEntity
  {
    private Gender gender;
    private string title;
    private string description;
    private int year;
    private bool deleted;

    public Series(int id, Gender gender, string title, string description, int year)
    {
      this.id = id;
      this.gender = gender;
      this.title = title;
      this.description = description;
      this.year = year;
      this.deleted = false;
    }

    public override string ToString()
    {
      string retn = "";
      retn += "Gender: " + this.gender + Environment.NewLine;
      retn += "Title: " + this.title + Environment.NewLine;
      retn += "Description: " + this.description + Environment.NewLine;
      retn += "Start Year of the series: " + this.year + Environment.NewLine;
      retn += "Deleted series? " + this.deleted;
      return retn;
    }

    public string ReturnTitle()
    {
      return this.title;
    }

    public int ReturnId()
    {
      return this.id;
    }

    public void Deleted()
    {
      this.deleted = true;
    }

    public bool returnDeleted()
		{
			return this.deleted;
		}
  }
}