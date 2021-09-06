using System;
using System.Collections.Generic;
using FlixNet.Interfaces;

namespace FlixNet
{
  public class SeriesRepository : IRepository<Series>
  {
    private List<Series> seriesList =  new List<Series>();

    public List<Series> ToList()
    {
      return seriesList;
    }

    public Series ReturnById(int id)
    {
      return seriesList[id];
    }
    public void Insert(Series series)
    {
      seriesList.Add(series);
    }

    public void Delete(int id)
    {
      seriesList[id].Deleted();
    }
    
    public void Update(int id, Series series)
    {
      seriesList[id] = series;
    }
    
    public int NextId()
    {
      return seriesList.Count;
    }

  }
}