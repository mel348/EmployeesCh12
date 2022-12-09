using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EmployeesCh12.Models
{
    public class DepartmentLocation
    {
        //Composite Primary Key and Foreign Key for Department
        public int DepartmentID { get; set; }
        //Composite Primary Key and Foreign Key for Location
        public int LocationID { get; set; }

        //Navigation Properties - They are both the "one" side of the relationship to the "many" which is now DepartmentLocation.
        public Department Department { get; set; }
        public Location Location { get; set; }
    }
}
