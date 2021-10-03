namespace CR160471_Desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombres = c.String(maxLength: 100),
                        primerapellido = c.String(maxLength: 50),
                        segundoapellido = c.String(maxLength: 50),
                        telefono = c.String(maxLength: 15),
                        correo = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cliente");
        }
    }
}
