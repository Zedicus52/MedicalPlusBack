using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.WebModels
{
    public class LogModel
    {
        public int IdLog { get; set; }
        public string IdUser { get; set; }
        public int? IdAction { get; set; }
        public string ObjectName { get; set; }
        public string Message { get; set; }


    }
}
