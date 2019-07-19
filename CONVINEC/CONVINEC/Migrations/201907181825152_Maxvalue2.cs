namespace CONVINEC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maxvalue2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuestionActivity", "description", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuestionActivity", "description", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
    }
}
