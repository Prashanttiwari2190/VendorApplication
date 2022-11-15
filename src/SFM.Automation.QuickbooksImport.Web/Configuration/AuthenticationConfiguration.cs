namespace SFM.Automation.QuickbooksImport.Web.Configuration
{
    public class AuthenticationConfiguration
    {
        public const string SectionName = "Authentication";

        public string Audience { get; set; } = "edf.app";

        public string Authority { get; set; }

        public bool Enabled { get; set; } = true;

        public string FakeUserId { get; set; }

        public string FakeUserName { get; set; }

        public string NameClaim { get; set; } = "name";

        public string UpnClaim { get; set; } = "upn";

        public bool UseFake { get; set; } = false;
    }
}