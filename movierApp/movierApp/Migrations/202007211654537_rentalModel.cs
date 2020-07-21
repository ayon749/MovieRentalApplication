﻿namespace movierApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentalModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_id = c.Int(nullable: false),
                        Movie_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_id, cascadeDelete: true)
                .Index(t => t.Customer_id)
                .Index(t => t.Movie_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_id" });
            DropIndex("dbo.Rentals", new[] { "Customer_id" });
            DropTable("dbo.Rentals");
        }
    }
}
