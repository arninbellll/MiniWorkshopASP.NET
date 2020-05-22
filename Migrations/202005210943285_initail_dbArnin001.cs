namespace MiniWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initail_dbArnin001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cart", "order_id", "dbo.order");
            DropForeignKey("dbo.cart", "product_id", "dbo.products");
            DropIndex("dbo.cart", new[] { "order_id" });
            DropIndex("dbo.cart", new[] { "product_id" });
            DropTable("dbo.cart");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.cart",
                c => new
                    {
                        order_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.order_id, t.product_id });
            
            CreateIndex("dbo.cart", "product_id");
            CreateIndex("dbo.cart", "order_id");
            AddForeignKey("dbo.cart", "product_id", "dbo.products", "product_id", cascadeDelete: true);
            AddForeignKey("dbo.cart", "order_id", "dbo.order", "order_id", cascadeDelete: true);
        }
    }
}
