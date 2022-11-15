using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFM.Automation.QuickbooksImport.Data.Migrations
{
    /// <summary>
    ///   The initial database migration.
    /// </summary>
    [Migration(2022111543)]
    public class Migration_2022111543 : ForwardOnlyMigration
    {
        /// <summary>
        ///   The script to migrate the database to the current version.
        /// </summary>
        public override void Up()
        {
            Create.Table("VendorLogin").InSchema("dbo")
             .WithColumn("VendorLoginId").AsInt32().Identity().PrimaryKey().NotNullable()
             .WithColumn("UserName").AsAnsiString(500).Nullable()
             .WithColumn("Password").AsAnsiString(500).Nullable()
             .WithColumn("VendorId").AsInt32().Nullable()
             .WithColumn("VendorName").AsAnsiString(500).Nullable();
        }
    }
}