namespace Patient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "IsDeleted");
            DropColumn("dbo.Doctors", "IsDeleted");
        }
    }
}
