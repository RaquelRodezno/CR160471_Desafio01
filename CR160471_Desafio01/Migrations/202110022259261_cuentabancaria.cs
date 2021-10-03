namespace CR160471_Desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cuentabancaria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cuentabancaria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        modena = c.String(maxLength: 50),
                        tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tipocuentabancaria", t => t.tipo, cascadeDelete: true)
                .Index(t => t.tipo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cuentabancaria", "tipo", "dbo.tipocuentabancaria");
            DropIndex("dbo.cuentabancaria", new[] { "tipo" });
            DropTable("dbo.cuentabancaria");
        }
    }
}
