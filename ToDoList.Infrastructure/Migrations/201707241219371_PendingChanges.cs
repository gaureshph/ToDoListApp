namespace ToDoList.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "NickName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NickName", c => c.String());
        }
    }
}
