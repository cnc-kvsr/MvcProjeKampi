namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_alter_writer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterPasswordHash", c => c.Binary());
            AddColumn("dbo.Writers", "WriterPasswordSalt", c => c.Binary());
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String());
            DropColumn("dbo.Writers", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "WriterPasswordSalt");
            DropColumn("dbo.Writers", "WriterPasswordHash");
        }
    }
}
