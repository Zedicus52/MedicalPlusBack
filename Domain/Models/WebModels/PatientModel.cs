using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.WebModels
{
    public class PatientModel
    {

        public int IdPatient { get; set; }

        public int PhoneNumber { get; set; }
        public int MedicalCardNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime ApplicationDate { get; set; }

        public virtual FioModel Fio{ get; set; }

        public virtual GenderModel Gender { get; set; }

    }
}
