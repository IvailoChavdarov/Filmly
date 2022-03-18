using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class EventDateComparer:IComparer<HistoryEvent>
    {
        public int Compare(HistoryEvent firstEvent, HistoryEvent secondEvent)
        {
            HistoryEventDate firstDate = firstEvent.EventDate;
            HistoryEventDate secondDate = secondEvent.EventDate;
            string firstYearString = firstDate.EventYear;
            string secondYearString = secondDate.EventYear;
            if (firstDate.EventYear.Contains('~'))
            {
                firstYearString = firstYearString.Trim('~');
            }
            if (secondDate.EventYear.Contains('~'))
            {
                secondYearString = secondYearString.Trim('~');
            }
            if (firstDate.ToString() == secondDate.ToString())
            {
                return 0;
            }
            if(firstDate.EventYear.Contains("B.C"))
            {
                firstYearString = firstYearString.Remove(firstYearString.IndexOf('B', 3)).TrimEnd();
                if (secondDate.EventYear.Contains("B.C"))
                {
                    secondYearString = secondYearString.Remove(secondYearString.IndexOf('B', 3)).TrimEnd();
                    return int.Parse(firstYearString) - int.Parse(secondYearString);
                }
                else
                {
                    return (int.Parse(firstYearString) + int.Parse(secondYearString))*-1;
                }
            }
            else
            {
                if (secondDate.EventYear.Contains("B.C"))
                {
                    secondYearString = secondYearString.Remove(secondYearString.IndexOf('B', 3)).TrimEnd();
                    return int.Parse(firstYearString) + int.Parse(secondYearString);
                }
                else
                {
                    return int.Parse(firstYearString) - int.Parse(secondYearString);
                }
            }
        }
    }
}
