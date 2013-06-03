using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListClass
/// </summary>
public class ListClass
{
    public IEnumerable<_514_List> GetList()
    {
        using (var dataContext = new ReminderDataContext())
        {
            return dataContext._514_Lists.Where(x => true).ToList();
        }
    }

    public _514_List GetListById(int id)
    {
        using (var dataContext = new ReminderDataContext())
        {
            return dataContext._514_Lists.Single(x => x.Id == id);
        }
    }
}