using System.Text.Json.Serialization;

namespace Domain.Models.WebModels
{
    [Serializable]
    public class FioModel
    {
        public int IdFio { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        [JsonConstructor]
        public FioModel(int IdFio, string Name, string Surname, string Patronymic)
        {
            this.IdFio = IdFio;
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
        }

    }
}
