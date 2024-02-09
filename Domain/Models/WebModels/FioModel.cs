using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.WebModels
{
    public class FioModel
    {
        public int IdFio { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public FioModel(int fioIdFio, string fioName, string fioSurname, string fioPatronymic)
        {
            IdFio = fioIdFio;
            Name = fioName;
            Surname = fioSurname;
            Patronymic = fioPatronymic;
        }
    }
}
