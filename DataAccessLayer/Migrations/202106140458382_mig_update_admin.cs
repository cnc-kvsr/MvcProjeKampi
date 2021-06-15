namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Admins", "AdminPassword");
            DropColumn("dbo.Admins", "PasswordSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "PasswordSalt", c => c.String());
            AddColumn("dbo.Admins", "AdminPassword", c => c.String());
            AlterColumn("dbo.Admins", "AdminRole", c => c.String());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminPasswordHash");
        }
    }
}
