namespace movierApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
			Sql(@"
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'663641bb-324e-48ca-a4da-4a700516e608', N'guest@vidly.com', 0, N'AONdfJ8eV+WVHUr0szA9XRxgKPVanvgjGKwMmghp4XL7WWC2S/PIt0iaTpzObk/pdg==', N'd9b0dacb-8964-417f-9b93-5cafa2f19003', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6f49ca66-6b60-45c2-9272-855f6a09e533', N'admin@vidly.com', 0, N'AMEXuO3MyS2fwEbSQJDrxAjKq6XAeRIKFS1tsDwtL4xTHD+n4jqJba7kphx975jFmw==', N'd04b2b0b-ce09-42bb-963d-861b595b1938', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9bb0e99b-83c9-408f-8f7e-166d4686850e', N'CanManageMovies')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6f49ca66-6b60-45c2-9272-855f6a09e533', N'9bb0e99b-83c9-408f-8f7e-166d4686850e')
              ");
        }
        
        public override void Down()
        {
        }
    }
}
