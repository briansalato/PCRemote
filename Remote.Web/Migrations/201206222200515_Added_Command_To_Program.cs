namespace Remote.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Added_Command_To_Program : DbMigration
    {
        public override void Up()
        {
            AddColumn("Programs", "Command", c => c.String(nullable: false));
            AlterColumn("Programs", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Programs", "Name", c => c.String());
            DropColumn("Programs", "Command");
        }
    }
}
