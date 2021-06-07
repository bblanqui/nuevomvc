namespace mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.municipios",
                c => new
                    {
                        id_municipio = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        nombre = c.String(),
                        activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_municipio);
            
            CreateTable(
                "dbo.municipios_regiones",
                c => new
                    {
                        id_regiones = c.Int(nullable: false),
                        id_municipio = c.Int(nullable: false),
                    })
                
                .ForeignKey("dbo.municipios", t => t.id_municipio, cascadeDelete: true)
                .ForeignKey("dbo.regiones", t => t.id_regiones, cascadeDelete: true)
                .Index(t => t.id_regiones)
                .Index(t => t.id_municipio);
            
            CreateTable(
                "dbo.regiones",
                c => new
                    {
                        id_regiones = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id_regiones);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.municipios_regiones", "id_regiones", "dbo.regiones");
            DropForeignKey("dbo.municipios_regiones", "id_municipio", "dbo.municipios");
            DropIndex("dbo.municipios_regiones", new[] { "id_municipio" });
            DropIndex("dbo.municipios_regiones", new[] { "id_regiones" });
            DropTable("dbo.regiones");
            DropTable("dbo.municipios_regiones");
            DropTable("dbo.municipios");
        }
    }
}
