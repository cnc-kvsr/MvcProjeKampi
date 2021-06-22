namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_alter_skill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "WriterID", c => c.Int());
            CreateIndex("dbo.Skills", "WriterID");
            AddForeignKey("dbo.Skills", "WriterID", "dbo.Writers", "WriterID");
            DropColumn("dbo.Skills", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Skills", "WriterID", "dbo.Writers");
            DropIndex("dbo.Skills", new[] { "WriterID" });
            DropColumn("dbo.Skills", "WriterID");
        }
    }
}
