using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmly.Models;
namespace Filmly.ViewModels
{
    public class UserCollectionVM:IViewModelWithBreadcrumb
    {
        public List<Titles> Collection { get; set; }
        public string CollectionName { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
    }
}
