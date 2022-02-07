using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class ActorCastInVM:IViewModelWithBreadcrumb
    {
        public ActorDataAPIModel ActorData { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
    }
}
