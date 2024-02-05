using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.WebModels
{
    public class ProblemModel
    {
        public int IdProblem { get; set; }

        public string IdUser { get; set; }

        public int IdDifficulty { get; set; }

        public string Diagnosis { get; set; } 

        public string MicroDesc { get; set; }

        public string MacroDesc { get; set; } 



    }
}
