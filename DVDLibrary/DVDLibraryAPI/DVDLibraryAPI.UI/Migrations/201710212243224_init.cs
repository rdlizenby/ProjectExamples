namespace DVDLibraryAPI.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingName = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.RatingId);

            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ReleaseYear = c.Int(nullable: false),
                        Director = c.String(nullable: false, maxLength: 50),
                        Notes = c.String(maxLength: 500),
                        RatingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.Ratings", t => t.RatingId)
                .Index(t => t.RatingId);
            

            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Dvds", new[] { "RatingId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Dvds");
        }
    }
}
