namespace S1_SailorMoon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aliadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreAliado = c.String(nullable: false),
                        Tipo = c.String(),
                        Edad = c.Int(nullable: false),
                        SailorSenshiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SailorSenshis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Planeta = c.String(),
                        NivelPoder = c.Int(nullable: false),
                        HabilidadEspecial = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SailorSenshis");
            DropTable("dbo.Aliadoes");
        }
    }
}
