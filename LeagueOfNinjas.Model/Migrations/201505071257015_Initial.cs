namespace LeagueOfNinjas.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Category", newName: "Categories");
            RenameTable(name: "dbo.Equip", newName: "Equips");
            RenameTable(name: "dbo.Ninja", newName: "Ninjas");
            RenameTable(name: "dbo.NinjaEquip", newName: "NinjaEquips");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.NinjaEquips", newName: "NinjaEquip");
            RenameTable(name: "dbo.Ninjas", newName: "Ninja");
            RenameTable(name: "dbo.Equips", newName: "Equip");
            RenameTable(name: "dbo.Categories", newName: "Category");
        }
    }
}
