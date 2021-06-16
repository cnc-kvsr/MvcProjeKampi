namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_alter_admin1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminUserNameHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminUserNameSalt", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            DropColumn("dbo.Admins", "AdminUserNameSalt");
            DropColumn("dbo.Admins", "AdminUserNameHash");
        }
    }
}
