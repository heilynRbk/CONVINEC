namespace CONVINEC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Maxvalue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionLog",
                c => new
                    {
                        pkActionLog = c.Int(nullable: false, identity: true),
                        fkTypeActionLog = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        notes = c.String(nullable: false, maxLength: 350, unicode: false),
                    })
                .PrimaryKey(t => t.pkActionLog)
                .ForeignKey("dbo.TypeActionLog", t => t.fkTypeActionLog)
                .Index(t => t.fkTypeActionLog);
            
            CreateTable(
                "dbo.TypeActionLog",
                c => new
                    {
                        pkTypeActionLog = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 50, unicode: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkTypeActionLog);
            
            CreateTable(
                "dbo.IndicatorHistory",
                c => new
                    {
                        pkIndicatorHistory = c.Int(nullable: false, identity: true),
                        fkTypeIndicator = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        description = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.pkIndicatorHistory)
                .ForeignKey("dbo.TypeIndicator", t => t.fkTypeIndicator)
                .Index(t => t.fkTypeIndicator);
            
            CreateTable(
                "dbo.TypeIndicator",
                c => new
                    {
                        codIndicadorInterno = c.Int(nullable: false),
                        description = c.String(nullable: false, maxLength: 50, unicode: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.codIndicadorInterno);
            
            CreateTable(
                "dbo.Occupation",
                c => new
                    {
                        pkOccupation = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 50, unicode: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkOccupation);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        pkUser = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, maxLength: 100, unicode: false),
                        DNI = c.String(nullable: false, maxLength: 11, unicode: false),
                        fullName = c.String(nullable: false, maxLength: 100, unicode: false),
                        birthdate = c.DateTime(nullable: false, storeType: "date"),
                        address = c.String(nullable: false, maxLength: 350, unicode: false),
                        fkOccupation = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkUser)
                .ForeignKey("dbo.Occupation", t => t.fkOccupation)
                .Index(t => t.fkOccupation);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        pkQuestion = c.Int(nullable: false, identity: true),
                        fkTopic = c.Int(nullable: false),
                        fullName = c.String(nullable: false, maxLength: 100, unicode: false),
                        date = c.DateTime(nullable: false),
                        tittle = c.String(nullable: false, maxLength: 50, unicode: false),
                        description = c.String(nullable: false, unicode: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkQuestion)
                .ForeignKey("dbo.Topic", t => t.fkTopic)
                .Index(t => t.fkTopic);
            
            CreateTable(
                "dbo.QuestionActivity",
                c => new
                    {
                        pkQuestionActivity = c.Int(nullable: false, identity: true),
                        fkQuestion = c.Int(nullable: false),
                        fkTypeAction = c.Int(nullable: false),
                        fullname = c.String(nullable: false, maxLength: 100, unicode: false),
                        date = c.DateTime(nullable: false),
                        description = c.String(nullable: false, maxLength: 250, unicode: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkQuestionActivity)
                .ForeignKey("dbo.TypeAction", t => t.fkTypeAction)
                .ForeignKey("dbo.Question", t => t.fkQuestion)
                .Index(t => t.fkQuestion)
                .Index(t => t.fkTypeAction);
            
            CreateTable(
                "dbo.TypeAction",
                c => new
                    {
                        pkTypeAction = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 50, unicode: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkTypeAction);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        pkTopic = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 50, unicode: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkTopic);
            
            CreateTable(
                "dbo.SystemLog",
                c => new
                    {
                        pkSystemLog = c.Int(nullable: false, identity: true),
                        table = c.String(nullable: false, maxLength: 100, unicode: false),
                        column = c.String(nullable: false, maxLength: 100, unicode: false),
                        previousValue = c.String(nullable: false, maxLength: 250, unicode: false),
                        date = c.DateTime(nullable: false),
                        notes = c.String(nullable: false, maxLength: 350, unicode: false),
                    })
                .PrimaryKey(t => t.pkSystemLog);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "fkTopic", "dbo.Topic");
            DropForeignKey("dbo.QuestionActivity", "fkQuestion", "dbo.Question");
            DropForeignKey("dbo.QuestionActivity", "fkTypeAction", "dbo.TypeAction");
            DropForeignKey("dbo.User", "fkOccupation", "dbo.Occupation");
            DropForeignKey("dbo.IndicatorHistory", "fkTypeIndicator", "dbo.TypeIndicator");
            DropForeignKey("dbo.ActionLog", "fkTypeActionLog", "dbo.TypeActionLog");
            DropIndex("dbo.QuestionActivity", new[] { "fkTypeAction" });
            DropIndex("dbo.QuestionActivity", new[] { "fkQuestion" });
            DropIndex("dbo.Question", new[] { "fkTopic" });
            DropIndex("dbo.User", new[] { "fkOccupation" });
            DropIndex("dbo.IndicatorHistory", new[] { "fkTypeIndicator" });
            DropIndex("dbo.ActionLog", new[] { "fkTypeActionLog" });
            DropTable("dbo.SystemLog");
            DropTable("dbo.Topic");
            DropTable("dbo.TypeAction");
            DropTable("dbo.QuestionActivity");
            DropTable("dbo.Question");
            DropTable("dbo.User");
            DropTable("dbo.Occupation");
            DropTable("dbo.TypeIndicator");
            DropTable("dbo.IndicatorHistory");
            DropTable("dbo.TypeActionLog");
            DropTable("dbo.ActionLog");
        }
    }
}
