using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class StaticPagesData : IViewModelWithBreadcrumb
    {
        public BreadcrumbData BreadcrumbData { get; set; }
    }
}
