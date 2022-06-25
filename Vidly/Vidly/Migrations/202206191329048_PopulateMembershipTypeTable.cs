namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SignupFee, DiscountRate) VALUES (1, 'PayAndGo', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SignupFee, DiscountRate) VALUES (2, 'Monthly', 1, 30, 10)");
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SignupFee, DiscountRate) VALUES (3, 'Quarterly', 3, 90, 15)");
            Sql("INSERT INTO MembershipTypes (Id, Name, DurationInMonths, SignupFee, DiscountRate) VALUES (4, 'Yearly', 12, 300, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
