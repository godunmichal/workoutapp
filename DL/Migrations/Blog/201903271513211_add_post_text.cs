namespace DL.Migrations.Blog
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_post_text : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfiles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfiles", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfiles", "City", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfiles", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "Email", c => c.String());
            AlterColumn("dbo.UserProfiles", "City", c => c.String());
            AlterColumn("dbo.UserProfiles", "Surname", c => c.String());
            AlterColumn("dbo.UserProfiles", "Name", c => c.String());
            AlterColumn("dbo.Posts", "Text", c => c.String());
            AlterColumn("dbo.Comments", "Text", c => c.String());
            DropColumn("dbo.Posts", "Title");
        }
    }
}
