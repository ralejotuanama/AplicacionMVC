namespace AplicacionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 50),
                        email = c.String(),
                        Document = c.String(nullable: false, maxLength: 30),
                        DocumentTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeID, cascadeDelete: true)
                .Index(t => t.DocumentTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "DocumentTypeID", "dbo.DocumentTypes");
            DropIndex("dbo.Customers", new[] { "DocumentTypeID" });
            DropTable("dbo.Customers");
        }
    }
}
