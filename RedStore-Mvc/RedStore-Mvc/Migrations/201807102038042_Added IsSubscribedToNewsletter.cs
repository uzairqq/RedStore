namespace RedStore_Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsSubscribedToNewsletter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}
