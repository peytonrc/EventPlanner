namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(nullable: false),
                        IsAllDay = c.Boolean(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        LocationName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        IsInside = c.Boolean(nullable: false),
                        TravelTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        TypeOfActivity = c.Int(nullable: false),
                        SubjectName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Event", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Event", "LocationID", "dbo.Location");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Event", new[] { "LocationID" });
            DropIndex("dbo.Event", new[] { "SubjectID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Subject");
            DropTable("dbo.Location");
            DropTable("dbo.Event");
        }
    }
}
