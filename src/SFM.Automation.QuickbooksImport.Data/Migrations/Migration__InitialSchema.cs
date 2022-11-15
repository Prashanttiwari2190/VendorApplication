using FluentMigrator;

namespace SFM.Automation.QuickbooksImport.Data.Migrations
{
    /// <summary>
    ///   The initial database migration.
    /// </summary>
    [Migration(0)]
    public class Migration__InitialSchema : ForwardOnlyMigration
    {
        /// <summary>
        ///   The script to migrate the database to the current version.
        /// </summary>
        public override void Up()
        {
            Create.Table("QuickBooks_Raw_Data").InSchema("dbo")
               .WithColumn("id").AsInt32().Identity().PrimaryKey().NotNullable()
               .WithColumn("Bill_No").AsAnsiString(100).Nullable()
               .WithColumn("Terms").AsAnsiString(100).Nullable()
               .WithColumn("Bill_Date").AsDate().Nullable()
               .WithColumn("Due_Date").AsDate().Nullable()
               .WithColumn("Bill_Amount").AsFloat().Nullable()
               .WithColumn("Vendor").AsAnsiString(1000).Nullable()
               .WithColumn("Category").AsAnsiString(1000).Nullable()
               .WithColumn("Vendor_Mailing_Address").AsAnsiString(1000).Nullable()
               .WithColumn("Category_Description").AsAnsiString(1000).Nullable()
               .WithColumn("Customer").AsAnsiString(500).Nullable()
               .WithColumn("Txn_Date").AsDate().Nullable();

            Create.Table("Fleetio_Raw_Data").InSchema("dbo")
               .WithColumn("id").AsInt32().Identity().PrimaryKey().NotNullable()
               .WithColumn("Order_id").AsInt32().NotNullable()
               .WithColumn("Number").AsAnsiString(55).Nullable()
               .WithColumn("Work_Order_Status_Name").AsAnsiString(55).Nullable()
               .WithColumn("Description").AsAnsiString(55).Nullable()
               .WithColumn("Purchase_Order_Number").AsAnsiString(100).Nullable()
               .WithColumn("Total_Amount").AsFloat().Nullable()
               .WithColumn("Completed_At").AsDate().Nullable()
               .WithColumn("Vehicle_Id").AsInt32().NotNullable()
               .WithColumn("Vehicle_Name").AsAnsiString(500).Nullable()
               .WithColumn("Vendor_id").AsInt32().NotNullable()
               .WithColumn("Vendor_Name").AsAnsiString(500).Nullable()
               .WithColumn("Tax_1_Type").AsAnsiString(225).Nullable()
               .WithColumn("Tax_1_Value").AsFloat().Nullable()
               .WithColumn("Tax_2_Type").AsAnsiString(225).Nullable()
               .WithColumn("Tax_2_Value").AsFloat().Nullable()
               .WithColumn("Discount_Type").AsAnsiString(225).Nullable()
               .WithColumn("Discount_Value").AsFloat().Nullable();
        }
    }
}