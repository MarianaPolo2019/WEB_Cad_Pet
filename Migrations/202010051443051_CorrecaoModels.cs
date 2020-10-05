namespace Cad_Pet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaoModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonoModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(),
                        Telefone = c.String(nullable: false),
                        Data_Cad = c.DateTime(nullable: false),
                        Descr_End = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PetModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome_Pet = c.String(nullable: false),
                        Tipo_Pet = c.String(nullable: false),
                        Sexo = c.String(),
                        Raca = c.String(),
                        Porte = c.String(nullable: false),
                        DonoId = c.Int(),
                        DonoModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonoModel", t => t.DonoModel_Id)
                .Index(t => t.DonoModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetModel", "DonoModel_Id", "dbo.DonoModel");
            DropIndex("dbo.PetModel", new[] { "DonoModel_Id" });
            DropTable("dbo.PetModel");
            DropTable("dbo.DonoModel");
        }
    }
}
