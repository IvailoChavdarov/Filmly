using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class TitleCastVM:IViewModelWithBreadcrumb
    {
        public TitleCastModel TitleData { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
    }
}
