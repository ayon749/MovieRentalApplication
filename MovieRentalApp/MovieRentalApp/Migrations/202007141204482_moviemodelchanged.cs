namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moviemodelchanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "RealeseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "AddTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "AddTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "RealeseDate", c => c.DateTime(nullable: false));
        }
    }
}
