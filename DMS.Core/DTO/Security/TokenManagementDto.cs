namespace DMS.Core.DTO.Security
{
    public class TokenManagementDto
    {

        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int AccessExpiration { get; set; }
        public int RefreshExpiration { get; set; }
    }
}
