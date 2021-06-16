namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_alter_admin_adminusername : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
        }
    }
}
