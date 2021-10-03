namespace CR160471_Desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipotransaccion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tipotransaccion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tipotransacciones = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tipotransaccion");
        }
    }
}
