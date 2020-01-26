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

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin'), (N'2', N'Member')");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], " +
                "[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], " +
                "[AccessFailedCount], [UserName]) VALUES (N'b31d9193-d5e5-4b02-9ab0-f6a201e5c4b3', N'admin@cdwebshop.com', " +
                "0, N'AB6hds6tLKa9kE6m+YZSOsgaJxc/O0ynygeK2LbGSF+M+BLOKSnF8xDGjjNq4ING9Q==', N'5738245b-6a06-45a3-afb9-b4b671696ea2', " +
                "NULL, 0, 0, NULL, 1, 0, N'admin@cdwebshop.com')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b31d9193-d5e5-4b02-9ab0-f6a201e5c4b3', N'1')");
        }
        
        public override void Down()
        {
        }
    }
}
