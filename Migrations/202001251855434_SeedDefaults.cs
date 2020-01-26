namespace CDWebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDefaults : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Subscriptions] ([Name]) VALUES (N'None'), " +
                "(N'Monthly'), (N'Half Year'), (N'Yearly')");
            Sql("INSERT INTO [dbo].[DiskTypes] ([Name]) VALUES (N'CD'), " +
                "(N'DVD'), (N'Blu-Ray')");
            Sql("INSERT INTO [dbo].[Categories] ([Name]) VALUES (N'Music'), " +
                "(N'Movie'), (N'Game')");
        }
        
        public override void Down()
        {
        }
    }
}
