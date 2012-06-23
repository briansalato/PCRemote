namespace Remote.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Added_Remote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Remotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ViewName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Programs", "Remote_Id", c => c.Int(nullable: false));
            AddForeignKey("Programs", "Remote_Id", "Remotes", "Id", cascadeDelete: true);
            CreateIndex("Programs", "Remote_Id");
        }
        
        public override void Down()
        {
            DropIndex("Programs", new[] { "Remote_Id" });
            DropForeignKey("Programs", "Remote_Id", "Remotes");
            DropColumn("Programs", "Remote_Id");
            DropTable("Remotes");
        }
    }
}
