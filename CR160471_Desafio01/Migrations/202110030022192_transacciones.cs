namespace CR160471_Desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transacciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.transacciones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        monto = c.Double(nullable: false),
                        estado = c.Boolean(nullable: false),
                        fechatransaccion = c.DateTime(nullable: false),
                        fechaaplicacion = c.DateTime(nullable: false),
                        tipotrans = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tipotransaccion", t => t.tipotrans, cascadeDelete: true)
                .Index(t => t.tipotrans);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.transacciones", "tipotrans", "dbo.tipotransaccion");
            DropIndex("dbo.transacciones", new[] { "tipotrans" });
            DropTable("dbo.transacciones");
        }
    }
}
