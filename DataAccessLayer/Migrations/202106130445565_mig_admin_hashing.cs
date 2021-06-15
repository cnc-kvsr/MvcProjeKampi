namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_hashing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PasswordSalt", c => c.String());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
            AlterColumn("dbo.Admins", "AdminRole", c => c.String());
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 200),
                        Password = c.String(),
                        PasswordSalt = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "PasswordSalt");
        }
    }
}
