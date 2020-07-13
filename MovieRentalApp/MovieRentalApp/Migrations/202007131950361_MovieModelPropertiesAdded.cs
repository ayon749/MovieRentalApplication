namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieModelPropertiesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "RealeseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AddTime");
            DropColumn("dbo.Movies", "RealeseDate");
        }
    }
}
