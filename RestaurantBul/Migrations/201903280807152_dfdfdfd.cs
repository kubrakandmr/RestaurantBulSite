namespace RestaurantBul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfdfdfd : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AddColumn("dbo.Comments", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Comments", "CommentID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "CommentID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Comments", "Id");
            AddPrimaryKey("dbo.Comments", "CommentID");
        }
    }
}
