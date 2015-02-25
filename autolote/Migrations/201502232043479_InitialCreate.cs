namespace autolote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tipos",
                c => new
                    {
                        TipoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tipos");
        }
    }
}
