namespace Remote.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Add_Programs_Users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RemoteUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("RemoteUsers", t => t.RemoteUser_Id)
                .Index(t => t.RemoteUser_Id);
            
            CreateTable(
                "RemoteUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("Programs", new[] { "RemoteUser_Id" });
            DropForeignKey("Programs", "RemoteUser_Id", "RemoteUsers");
            DropTable("RemoteUsers");
            DropTable("Programs");
        }
    }
}
