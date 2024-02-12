namespace Domain.Models.WebModels
{
    public class EmployeeModel
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }

        public string? Password { get; set; }
        public string? CurrentPassword { get; set; }

        public string? Email { get; set; }

        public virtual FioModel Fio { get; set; }
        public virtual GenderModel Gender { get; set; }
        public virtual RoleModel Role { get; set; }
    }
}
