namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameManagerRole : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AspNetRoles SET Name = 'CanManageMoviesAndCustomers' WHERE Id = '453619f9-7678-4da6-8fb8-46d2f718a1d2'");
        }

        public override void Down()
        {
        }
    }
}
