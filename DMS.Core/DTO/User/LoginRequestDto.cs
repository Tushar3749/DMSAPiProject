namespace DMS.Core.Dto
{
    public class LoginRequestDto
    {
        public string EmployeeID { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string GrantType { get; set; }
        public string PasswordInPlainText { get; set; }

    }
}
