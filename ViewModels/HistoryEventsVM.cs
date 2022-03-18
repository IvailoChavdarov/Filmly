using Filmly.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class HistoryEventsVM : IViewModelWithBreadcrumb
    {
        public HistoryEventsVM()
        {
            SortedSet<HistoryEvent> historyEvents = new SortedSet<HistoryEvent>(new EventDateComparer());
            historyEvents.UnionWith(JSONHelper.GetLocalDataAsListOfObjects<HistoryEvent>("CinemaHistory"));
            this.Events = historyEvents.GroupBy(x => x.EventDate.EventYear);
        }
        public IEnumerable<IGrouping<string, HistoryEvent>> Events { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
    }
    public class HistoryEvent
    {
        public string EventTitle { get; set; }
        public string EventInfo { get; set; }
        public string EventImage { get; set; }
        public HistoryEventDate EventDate { get; set; }
    }
    public class HistoryEventDate
    {
        public string EventYear { get; set; }
        public int? EventMonth { get; set; }
        public string EventDay { get; set; }
        public override string ToString()
        {
            string date = this.EventYear;
            if (this.EventMonth.HasValue && this.EventMonth.Value > 0 && this.EventMonth <= 12)
            {
                date = date + " " + NameSimplifiers.Months[this.EventMonth];
                if (!string.IsNullOrEmpty(this.EventDay))
                {
                    int EventDayAsInt = int.Parse(this.EventDay);
                    if (EventDayAsInt > 0 && EventDayAsInt <= 31)
                    {
                        date = date + " " + this.EventDay;
                        char dateLastChar = this.EventDay.Last();
                        if (dateLastChar == '1')
                        {
                            date = date + "st";
                        }
                        else if (dateLastChar == '2')
                        {
                            date = date + "nd";
                        }
                        else if (dateLastChar == '3')
                        {
                            date = date + "rd";
                        }
                        else
                        {
                            date = date + "th";
                        }
                    }
                }
            }
            return date;
        }
        public string ToStringWithoutYear()
        {
            string date = "";
            if (this.EventMonth.HasValue && this.EventMonth.Value > 0 && this.EventMonth <= 12)
            {
                date = date + NameSimplifiers.Months[this.EventMonth];
                if (!string.IsNullOrEmpty(this.EventDay))
                {
                    int EventDayAsInt = int.Parse(this.EventDay);
                    if (EventDayAsInt > 0 && EventDayAsInt <= 31)
                    {
                        date = date + " " + this.EventDay;
                        char dateLastChar = this.EventDay.Last();
                        if (dateLastChar == '1')
                        {
                            if (date.Contains("01"))
                            {
                                date = date.Replace("01", "1");
                            }
                            date = date + "st";
                        }
                        else if (dateLastChar == '2')
                        {
                            date = date + "nd";
                        }
                        else if (dateLastChar == '3')
                        {
                            date = date + "rd";
                        }
                        else
                        {
                            date = date + "th";
                        }
                    }
                }
            }
            return date;
        }
        public string ToStringWithConnector()
        {
            string date = this.EventYear;
            if (this.EventMonth.HasValue && this.EventMonth.Value > 0 && this.EventMonth <= 12)
            {
                date = date + "_" + NameSimplifiers.Months[this.EventMonth];
                if (!string.IsNullOrEmpty(this.EventDay))
                {
                    int EventDayAsInt = int.Parse(this.EventDay);
                    if (EventDayAsInt > 0 && EventDayAsInt <= 31)
                    {
                        date = date + "_" + this.EventDay;
                        char dateLastChar = this.EventDay.Last();
                        if (dateLastChar == '1')
                        {
                            date = date + "st";
                        }
                        else if (dateLastChar == '2')
                        {
                            date = date + "nd";
                        }
                        else if (dateLastChar == '3')
                        {
                            date = date + "rd";
                        }
                        else
                        {
                            date = date + "th";
                        }
                    }
                }
            }
            return date;
        }
    }
}
