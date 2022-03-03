using Filmly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class ActorDetailsVM:IViewModelWithBreadcrumb
    {
        public Actors Data { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
        public List<Titles> StarredIn { get; set; }
    }
}
