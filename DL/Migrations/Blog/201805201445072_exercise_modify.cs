namespace DL.Migrations.Blog
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exercise_modify : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercises", "PostId", "dbo.Posts");
            DropIndex("dbo.Exercises", new[] { "PostId" });
            DropColumn("dbo.Exercises", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exercises", "PostId");
            AddForeignKey("dbo.Exercises", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
