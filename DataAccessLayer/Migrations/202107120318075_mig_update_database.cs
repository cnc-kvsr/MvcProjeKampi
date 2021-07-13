namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_database : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminUserNameHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminUserNameSalt", c => c.Binary());
            DropColumn("dbo.Admins", "AdminMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminMail", c => c.Binary());
            DropColumn("dbo.Admins", "AdminUserNameSalt");
            DropColumn("dbo.Admins", "AdminUserNameHash");
        }
    }
}
