namespace RestaurantBul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erererer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Comments", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserID", c => c.Int());
            AddColumn("dbo.Comments", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "ApplicationUser_Id");
            AddForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
