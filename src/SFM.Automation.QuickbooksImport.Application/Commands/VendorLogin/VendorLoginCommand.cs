using MediatR;
using SFM.Automation.QuickbooksImport.Domain.Models;

namespace SFM.Automation.QuickbooksImport.Application.Commands.VendorLogin
{
    /// <summary>
    ///   A command to Import objects from Quickbooks API.
    /// </summary>
    public class VendorLoginCommand : Command<string>
    {
        // private string username;
        // private string pwd;

        public VendorLoginCommand(string username, string pwd)
        {
            this.Username = username;
            this.Password = pwd;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}