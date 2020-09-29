namespace EventPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationModel : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Location");
        }
    }
}
