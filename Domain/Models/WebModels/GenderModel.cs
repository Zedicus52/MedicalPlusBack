using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.WebModels
{
    public class GenderModel
    {
        public int IdGender { get; set; }

        public string Name { get; set; }

        public GenderModel(int genderIdGender, string genderName)
        {
            IdGender = genderIdGender;
            Name = genderName;
        }
    }
}
