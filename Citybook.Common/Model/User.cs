using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citybook.Common.Model
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tz { get; set; }
        public string Birthdate { get; set; }
        public string MaleOrFemale { get; set; }
        public string HealthFund { get; set; }
        public List<Child> Children { get; set; }
    }
}
