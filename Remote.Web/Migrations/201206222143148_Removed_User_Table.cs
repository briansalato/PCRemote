namespace Remote.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Removed_User_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("RemoteUserPrograms", "RemoteUser_Id", "RemoteUsers");
            DropForeignKey("RemoteUserPrograms", "Program_Id", "Programs");
            DropIndex("RemoteUserPrograms", new[] { "RemoteUser_Id" });
            DropIndex("RemoteUserPrograms", new[] { "Program_Id" });
            DropTable("RemoteUsers");
            DropTable("RemoteUserPrograms");
        }
        
        public override void Down()
        {
            CreateTable(
                "RemoteUserPrograms",
                c => new
                    {
                        RemoteUser_Id = c.Int(nullable: false),
                        Program_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RemoteUser_Id, t.Program_Id });
            
            CreateTable(
                "RemoteUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("RemoteUserPrograms", "Program_Id");
            CreateIndex("RemoteUserPrograms", "RemoteUser_Id");
            AddForeignKey("RemoteUserPrograms", "Program_Id", "Programs", "Id", cascadeDelete: true);
            AddForeignKey("RemoteUserPrograms", "RemoteUser_Id", "RemoteUsers", "Id", cascadeDelete: true);
        }
    }
}
