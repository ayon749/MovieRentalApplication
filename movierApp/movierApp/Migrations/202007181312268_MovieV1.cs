namespace movierApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false),
                        RealeseDate = c.DateTime(nullable: false),
                        AddTime = c.DateTime(),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
