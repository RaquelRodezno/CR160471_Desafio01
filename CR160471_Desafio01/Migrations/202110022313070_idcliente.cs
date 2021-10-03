namespace CR160471_Desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idcliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cuentabancaria", "idcliente", c => c.Int(nullable: false));
            CreateIndex("dbo.cuentabancaria", "idcliente");
            AddForeignKey("dbo.cuentabancaria", "idcliente", "dbo.cliente", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cuentabancaria", "idcliente", "dbo.cliente");
            DropIndex("dbo.cuentabancaria", new[] { "idcliente" });
            DropColumn("dbo.cuentabancaria", "idcliente");
        }
    }
}
