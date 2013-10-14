namespace EFCodeFirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "DateCreated");
        }
    }
}
