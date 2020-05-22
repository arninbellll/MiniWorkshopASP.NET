namespace MiniWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initail_dbArnin0010 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cartdetail", "product_ProductId", "dbo.products");
            DropIndex("dbo.cartdetail", new[] { "product_ProductId" });
            DropColumn("dbo.cart", "Discount");
            DropTable("dbo.cartdetail");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.cartdetail",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            AddColumn("dbo.cart", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.cartdetail", "product_ProductId");
            AddForeignKey("dbo.cartdetail", "product_ProductId", "dbo.products", "product_id");
        }
    }
}
