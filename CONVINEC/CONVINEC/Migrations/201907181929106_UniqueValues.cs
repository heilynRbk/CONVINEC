namespace CONVINEC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueValues : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TypeActionLog", "description", unique: true);
            CreateIndex("dbo.TypeIndicator", "description", unique: true);
            CreateIndex("dbo.Occupation", "description", unique: true);
            CreateIndex("dbo.User", "email", unique: true);
            CreateIndex("dbo.User", "DNI", unique: true);
            CreateIndex("dbo.TypeAction", "description", unique: true);
            CreateIndex("dbo.Topic", "description", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Topic", new[] { "description" });
            DropIndex("dbo.TypeAction", new[] { "description" });
            DropIndex("dbo.User", new[] { "DNI" });
            DropIndex("dbo.User", new[] { "email" });
            DropIndex("dbo.Occupation", new[] { "description" });
            DropIndex("dbo.TypeIndicator", new[] { "description" });
            DropIndex("dbo.TypeActionLog", new[] { "description" });
        }
    }
}
