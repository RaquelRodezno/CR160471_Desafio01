namespace CR160471_Desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipocuentabancaria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tipocuentabancaria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tipocuenta = c.String(maxLength: 50),
                        activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tipocuentabancaria");
        }
    }
}
