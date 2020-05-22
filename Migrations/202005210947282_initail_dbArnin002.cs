namespace MiniWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initail_dbArnin002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cart",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cart", "ProductId", "dbo.products");
            DropIndex("dbo.cart", new[] { "ProductId" });
            DropTable("dbo.cart");
        }
    }
}
