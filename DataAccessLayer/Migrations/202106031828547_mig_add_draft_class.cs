namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_draft_class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drafts",
                c => new
                    {
                        DraftID = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        DraftContent = c.String(),
                        DraftDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DraftID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drafts");
        }
    }
}
