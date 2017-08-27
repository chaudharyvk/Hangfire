namespace RouteDelivery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcatalog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerLocation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        TransportType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DeliverySchedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OptimizationRequestID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        PackageID = c.Int(nullable: false),
                        TransportType = c.Int(nullable: false),
                        DriverName = c.String(),
                        EstimatedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DriverName = c.String(),
                        TransportType = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        StartLocation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OptimizationRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        ScheduleDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OptimizationRequests");
            DropTable("dbo.Drivers");
            DropTable("dbo.DeliverySchedules");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Customers");
        }
    }
}
