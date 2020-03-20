namespace ProyectoFinalAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documento",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                        UsernameId = c.Int(nullable: false),
                        Version_Doc = c.String(nullable: false, maxLength: 50, unicode: false),
                        Fecha_Creacion = c.DateTime(nullable: false),
                        Fecha_Modificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Login", t => t.UsernameId)
                .Index(t => t.UsernameId);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        RepeatPassword = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personal",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UsernameId = c.Int(nullable: false),
                        Puesto = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Login", t => t.UsernameId)
                .Index(t => t.UsernameId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UsernameId = c.Int(nullable: false),
                        EmailId = c.Int(nullable: false),
                        Puesto = c.String(nullable: false, maxLength: 100, unicode: false),
                        Nivel = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Login", t => t.UsernameId)
                .ForeignKey("dbo.Login", t => t.EmailId)
                .Index(t => t.UsernameId)
                .Index(t => t.EmailId);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "EmailId", "dbo.Login");
            DropForeignKey("dbo.Usuario", "UsernameId", "dbo.Login");
            DropForeignKey("dbo.Personal", "UsernameId", "dbo.Login");
            DropForeignKey("dbo.Documento", "UsernameId", "dbo.Login");
            DropIndex("dbo.Usuario", new[] { "EmailId" });
            DropIndex("dbo.Usuario", new[] { "UsernameId" });
            DropIndex("dbo.Personal", new[] { "UsernameId" });
            DropIndex("dbo.Documento", new[] { "UsernameId" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Usuario");
            DropTable("dbo.Personal");
            DropTable("dbo.Login");
            DropTable("dbo.Documento");
        }
    }
}
