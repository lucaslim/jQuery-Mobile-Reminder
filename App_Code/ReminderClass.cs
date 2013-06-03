using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

public class ReminderClass
{
    public IEnumerable<_514_Reminder> GetReminders()
    {
        using (var dataContext = new ReminderDataContext())
        {
            return dataContext._514_Reminders.Where(x => x.IsActive == true).OrderBy(x => x.Date).ToList();
        }
    }

    public void Insert(_514_Reminder reminder)
    {
        using (var dataContext = new ReminderDataContext())
        {
            dataContext._514_Reminders.InsertOnSubmit(reminder);
            dataContext.SubmitChanges();
        }
    }

    public _514_Reminder GetReminderById(int id)
    {
        using (var dataContext = new ReminderDataContext())
        {
            var options = new DataLoadOptions();
            options.LoadWith<_514_Reminder>(x => x._514_List);
            dataContext.LoadOptions = options;

            return dataContext._514_Reminders.SingleOrDefault(x => x.Id == id);
        }
    }

    public void DeleteReminderById(int id)
    {
        using (var dataContext = new ReminderDataContext())
        {
            var reminder = dataContext._514_Reminders.Single(x => x.Id == id);
            dataContext._514_Reminders.DeleteOnSubmit(reminder);
            dataContext.SubmitChanges();
        }
    }

    public void Update(_514_Reminder reminder)
    {
        using (var dataContext = new ReminderDataContext())
        {
            var data = dataContext._514_Reminders.Single(x => x.Id == reminder.Id);

            data.IsActive = reminder.IsActive;
            data.Date = reminder.Date;
            data.Title = reminder.Title;
            data.ListId = reminder.ListId;
            data.Notes = reminder.Notes;
            data.Priority = reminder.Priority;

            dataContext.SubmitChanges();
        }
    }

    public IEnumerable<_514_Reminder> GetRemindersByListId(int id)
    {
        using (var dataContext = new ReminderDataContext())
        {
            var options = new DataLoadOptions();
            options.LoadWith<_514_Reminder>(x => x._514_List);
            dataContext.LoadOptions = options;

            return dataContext._514_Reminders.Where(x => x.ListId == id)
                                             .OrderBy(x => x.IsActive == true)
                                             .ThenBy(x => x.Date)
                                             .ToList();
        }
    }

    public bool SetReminderIsActive(int id, bool complete)
    {
        using (var dataContext = new ReminderDataContext())
        {
            var data = dataContext._514_Reminders.Single(x => x.Id == id);
            data.IsActive = complete;
            dataContext.SubmitChanges();

            return true;
        }
    }
}