namespace S3_P4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        estudianteId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        edad = c.Int(nullable: false),
                        carrera = c.String(),
                    })
                .PrimaryKey(t => t.estudianteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Estudiantes");
        }
    }
}
