using System;
using System.Collections.Generic;

namespace DummyEF.Model
{
    public partial class Dumm
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string IpAddress { get; set; } = null!;
    }
}
