namespace GameLibrary.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDb3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameLibraryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Description = c.String(nullable: false),
                        GameSystem = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameLibraryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Games");
        }
    }
}
