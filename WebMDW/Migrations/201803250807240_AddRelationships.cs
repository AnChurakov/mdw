namespace WebMDW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriorityModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateBegin = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Priority_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriorityModels", t => t.Priority_Id)
                .Index(t => t.Priority_Id);
            
            CreateTable(
                "dbo.ProjectModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        DateBegin = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        UrlProjectDemo = c.String(),
                        ProcentComplete = c.Int(nullable: false),
                        Stages_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StageModels", t => t.Stages_Id)
                .Index(t => t.Stages_Id);
            
            CreateTable(
                "dbo.StageModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserProjectModels",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ProjectModel_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ProjectModel_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProjectModels", t => t.ProjectModel_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ProjectModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserProjectModels", "ProjectModel_Id", "dbo.ProjectModels");
            DropForeignKey("dbo.ApplicationUserProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectModels", "Stages_Id", "dbo.StageModels");
            DropForeignKey("dbo.TaskModels", "Priority_Id", "dbo.PriorityModels");
            DropIndex("dbo.ApplicationUserProjectModels", new[] { "ProjectModel_Id" });
            DropIndex("dbo.ApplicationUserProjectModels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectModels", new[] { "Stages_Id" });
            DropIndex("dbo.TaskModels", new[] { "Priority_Id" });
            DropTable("dbo.ApplicationUserProjectModels");
            DropTable("dbo.StatusModels");
            DropTable("dbo.StageModels");
            DropTable("dbo.ProjectModels");
            DropTable("dbo.TaskModels");
            DropTable("dbo.PriorityModels");
        }
    }
}
