namespace RestaurantBul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeterrrr : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameIndex(table: "dbo.Comments", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Comments", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
