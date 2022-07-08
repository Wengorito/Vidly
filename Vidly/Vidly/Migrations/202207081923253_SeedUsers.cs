namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'03636300-34e2-48eb-a281-7b199c4d0fc5', N'admin@vidly.com', 0, N'APxag80orfI+i0DeLBqqyTQL82c/jioClJnB+zkn7re//FTtoh/EZv8Wgbsahr4bcg==', N'9256bd7b-4773-4090-bfbf-0f15fe3fedb0', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f5596165-f51d-4bc0-b0a9-f511e3f1c52b', N'guest@vidly.com', 0, N'APLvYgWhahR71KPWPoHNeOfpt90INONzr1yBv7IiXmwuCYk6T2fYoP3JqbKjT9Ru9A==', N'034ffbbe-6671-490c-8be0-7147dfb2ce3d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'453619f9-7678-4da6-8fb8-46d2f718a1d2', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'03636300-34e2-48eb-a281-7b199c4d0fc5', N'453619f9-7678-4da6-8fb8-46d2f718a1d2')
");
        }
        
        public override void Down()
        {
        }
    }
}
