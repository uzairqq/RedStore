namespace RedStore_Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b26c639b-97a8-49a2-b7e7-19d2b41e8b4e', N'admin@vidly.com', 0, N'AOoGpcWV3wPTl3/7jcFMcum/dOm/hB8ePsMqgQKNdcMJ4xWt4PNpvFNU586DqCkoYQ==', N'8bee3075-fc67-4f9b-8a24-a7d186f10ec4', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dccbcb82-1f12-4325-8d51-0dc963fb9ae0', N'guest@vidly.com', 0, N'ABsdJ/wCuoYaadxFvD2f332WK/mboUQXcrU1Sa0+AEC1aux+Vsvecn7Vp/5TyfAVFA==', N'e5e2fb9c-a5c7-4cf6-93b5-8fd3a2dd75c1', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'558e66ef-9253-4ea4-86bb-0bc581f519d3', N'canManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b26c639b-97a8-49a2-b7e7-19d2b41e8b4e', N'558e66ef-9253-4ea4-86bb-0bc581f519d3')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dccbcb82-1f12-4325-8d51-0dc963fb9ae0', N'558e66ef-9253-4ea4-86bb-0bc581f519d3')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
