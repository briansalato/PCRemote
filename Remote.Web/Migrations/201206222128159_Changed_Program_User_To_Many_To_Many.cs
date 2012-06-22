namespace Remote.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Changed_Program_User_To_Many_To_Many : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Programs", "RemoteUser_Id", "RemoteUsers");
            DropIndex("Programs", new[] { "RemoteUser_Id" });
            CreateTable(
                "RemoteUserPrograms",
                c => new
                    {
                        RemoteUser_Id = c.Int(nullable: false),
                        Program_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RemoteUser_Id, t.Program_Id })
                .ForeignKey("RemoteUsers", t => t.RemoteUser_Id, cascadeDelete: true)
                .ForeignKey("Programs", t => t.Program_Id, cascadeDelete: true)
                .Index(t => t.RemoteUser_Id)
                .Index(t => t.Program_Id);
            
            DropColumn("Programs", "RemoteUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("Programs", "RemoteUser_Id", c => c.Int());
            DropIndex("RemoteUserPrograms", new[] { "Program_Id" });
            DropIndex("RemoteUserPrograms", new[] { "RemoteUser_Id" });
            DropForeignKey("RemoteUserPrograms", "Program_Id", "Programs");
            DropForeignKey("RemoteUserPrograms", "RemoteUser_Id", "RemoteUsers");
            DropTable("RemoteUserPrograms");
            CreateIndex("Programs", "RemoteUser_Id");
            AddForeignKey("Programs", "RemoteUser_Id", "RemoteUsers", "Id");
        }
    }
}
