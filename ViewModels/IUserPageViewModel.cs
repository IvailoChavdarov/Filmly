using Filmly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public interface IUserPageModel
    {
        public ApplicationUser UserData { get; set; }
    }
}
