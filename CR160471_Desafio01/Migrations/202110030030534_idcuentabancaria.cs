namespace CR160471_Desafio01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idcuentabancaria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.transacciones", "idcuentabancaria", c => c.Int(nullable: false));
            CreateIndex("dbo.transacciones", "idcuentabancaria");
            AddForeignKey("dbo.transacciones", "idcuentabancaria", "dbo.cuentabancaria", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.transacciones", "idcuentabancaria", "dbo.cuentabancaria");
            DropIndex("dbo.transacciones", new[] { "idcuentabancaria" });
            DropColumn("dbo.transacciones", "idcuentabancaria");
        }
    }
}
