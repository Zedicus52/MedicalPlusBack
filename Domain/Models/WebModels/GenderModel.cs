using System.Text.Json.Serialization;

namespace Domain.Models.WebModels
{
    [Serializable]
    public class GenderModel
    {
        public int IdGender { get; set; }

        public string Name { get; set; }


        [JsonConstructor]
        public GenderModel(int IdGender, string Name)
        {
            this.IdGender = IdGender;
            this.Name = Name;
        }
    }
}
