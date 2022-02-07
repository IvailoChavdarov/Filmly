using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public interface IViewModelWithBreadcrumb
    {
        public BreadcrumbData BreadcrumbData{get;set;}
    }
    public class BreadcrumbData
    {
        //public int PassedParameters()
        //{
        //    int publicNames = 0;
        //    if (!string.IsNullOrEmpty(this.ControllerPublicName))
        //    {
        //        publicNames++;
        //        if (!string.IsNullOrEmpty(this.ActionPublicName))
        //        {
        //            publicNames++;
        //            if (!string.IsNullOrEmpty(this.IdPublicName))
        //            {
        //                publicNames++;
        //            }
        //        }
        //    }
        //    return publicNames;
        //}
        public string ControllerPublicName { get; set; }
        public string ControllerName { get; set; }
        public string ActionPublicName { get; set; }
        public string ActionName { get; set; }
        public string IdPublicName { get; set; }
        public string IdName { get; set; }
        public bool HiddenAction { get; set; } = false;
        public bool HiddenController { get; set; } = false;
    }
}
