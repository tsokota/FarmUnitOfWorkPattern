namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFarmCostColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FarmEntities", "Cost", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FarmEntities", "Cost");
        }
    }
}
