namespace MVCLab04.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.catogery",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.news",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        pref = c.String(),
                        desc = c.String(nullable: false),
                        photo = c.String(maxLength: 50),
                        user_id = c.Int(),
                        catogery_id = c.Int(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.user_id)
                .ForeignKey("dbo.catogery", t => t.catogery_id)
                .Index(t => t.user_id)
                .Index(t => t.catogery_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50, unicode: false),
                        email = c.String(nullable: false, maxLength: 50, unicode: false),
                        password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.news", "catogery_id", "dbo.catogery");
            DropForeignKey("dbo.news", "user_id", "dbo.users");
            DropIndex("dbo.news", new[] { "catogery_id" });
            DropIndex("dbo.news", new[] { "user_id" });
            DropTable("dbo.users");
            DropTable("dbo.news");
            DropTable("dbo.catogery");
        }
    }
}
