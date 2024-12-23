namespace LibraryHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SettingKey = c.String(),
                        SettingName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        BirthCity = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ReleaseYear = c.Int(nullable: false),
                        BookGenre = c.String(nullable: false),
                        PagesCount = c.Int(nullable: false),
                        IdAuthor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.IdAuthor, cascadeDelete: true)
                .Index(t => t.IdAuthor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "IdAuthor", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "IdAuthor" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.AppSettings");
        }
    }
}
