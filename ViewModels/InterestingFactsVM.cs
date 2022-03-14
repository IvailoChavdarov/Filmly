using Filmly.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class InterestingFactsVM:IViewModelWithBreadcrumb
    {
        public InterestingFactsVM()
        {
          this.Facts = JSONHelper.GetLocalDataAsListOfObjects<InterestingFact>("InterestingFacts");
        }
            public List<InterestingFact> Facts { get; set; }
            public BreadcrumbData BreadcrumbData { get; set; }

    }
    public class InterestingFact
    {
        public string FactTitle { get; set; }
        public string FactInfo { get; set; }
        public string FactImage { get; set; }
    }
}
