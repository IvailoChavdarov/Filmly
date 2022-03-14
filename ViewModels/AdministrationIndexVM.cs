using Filmly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class AdministrationIndexVM : IUserPageModel
    {
        public ApplicationUser UserData { get; set; }
        public List<UserRole> UsersRoles { get; set; }
        public List<InterestingFact> InterestingFacts { get; set; }
        public List<HistoryEvent> HistoryEvents { get; set; }
    }
    public class UserRole
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
