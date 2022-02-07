using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    [NotMapped]

    public class SearchResultVM:IViewModelWithBreadcrumb
    {
        public string SearchType { get; set; }
        public string Expression { get; set; }
        public Result[] Results { get; set; }
        public string ErrorMessage { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
    }

    public class Result
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

}
