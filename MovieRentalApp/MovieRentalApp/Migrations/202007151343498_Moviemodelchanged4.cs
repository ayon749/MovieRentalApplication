namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moviemodelchanged4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "RealeseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "RealeseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "MovieName", c => c.String());
        }
    }
}
