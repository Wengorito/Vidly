using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Core.Domain
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte DurationInMonths { get; set; }
        public short SignupFee { get; set; }
        public short DiscountRate { get; set; }

    }
}