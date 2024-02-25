using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public int? IdFio { get; set; }
        public int? IdGender { get; set; }
        public virtual Fio? IdFioNavigation { get; set; }
        public virtual Gender? IdGenderNavigation { get; set; }
        public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

        public virtual ICollection<Problem> Problems { get; set; } = new List<Problem>();
    }
}
