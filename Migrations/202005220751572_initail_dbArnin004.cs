namespace MiniWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initail_dbArnin004 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cart", "Cart_CartId", c => c.Int());
            CreateIndex("dbo.cart", "Cart_CartId");
            AddForeignKey("dbo.cart", "Cart_CartId", "dbo.cart", "CartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cart", "Cart_CartId", "dbo.cart");
            DropIndex("dbo.cart", new[] { "Cart_CartId" });
            DropColumn("dbo.cart", "Cart_CartId");
        }
    }
}
