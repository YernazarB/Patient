namespace Patient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReceptionHistoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceptionHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Complaint = c.String(),
                        Diagnosis = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceptionHistories", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.ReceptionHistories", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.ReceptionHistories", new[] { "DoctorId" });
            DropIndex("dbo.ReceptionHistories", new[] { "PatientId" });
            DropTable("dbo.ReceptionHistories");
        }
    }
}
