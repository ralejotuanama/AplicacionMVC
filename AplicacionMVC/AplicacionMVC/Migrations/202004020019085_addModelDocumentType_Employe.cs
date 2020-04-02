namespace AplicacionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModelDocumentType_Employe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        DocumentTypeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DocumentTypeID);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfBirth = c.DateTime(nullable: false),
                        DocumentTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeId)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeID, cascadeDelete: true)
                .Index(t => t.DocumentTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "DocumentTypeID", "dbo.DocumentTypes");
            DropIndex("dbo.Employes", new[] { "DocumentTypeID" });
            DropTable("dbo.Employes");
            DropTable("dbo.DocumentTypes");
        }
    }
}
