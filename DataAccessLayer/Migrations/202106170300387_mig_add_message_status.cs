namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_message_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Messages", "SenderMail", c => c.String());
            AlterColumn("dbo.Messages", "ReceiverMail", c => c.String());
            AlterColumn("dbo.Messages", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Subject", c => c.String(maxLength: 100));
            AlterColumn("dbo.Messages", "ReceiverMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Messages", "SenderMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Messages", "MessageStatus");
        }
    }
}
