namespace EFCodeFirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        IDBlog = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IDBlog);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        IDPost = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        IDBlog = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDPost)
                .ForeignKey("dbo.Blogs", t => t.IDBlog, cascadeDelete: true)
                .Index(t => t.IDBlog);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "IDBlog" });
            DropForeignKey("dbo.Posts", "IDBlog", "dbo.Blogs");
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}
