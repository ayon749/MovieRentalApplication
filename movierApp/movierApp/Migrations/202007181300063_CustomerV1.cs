namespace movierApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribeToNewsLetter = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
