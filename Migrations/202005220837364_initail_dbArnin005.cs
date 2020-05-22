namespace MiniWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initail_dbArnin005 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.products", t => t.product_ProductId)
                .Index(t => t.product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cartdetail", "product_ProductId", "dbo.products");
            DropIndex("dbo.cartdetail", new[] { "product_ProductId" });
            DropTable("dbo.cartdetail");
        }
    }
}
