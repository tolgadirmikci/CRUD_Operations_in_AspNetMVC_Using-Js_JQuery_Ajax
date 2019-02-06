namespace MVCCRUD_DATATABLE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [StringLength(20),Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }

        [StringLength(20), Required(ErrorMessage = "This field is required")]
        public string Position { get; set; }

        [StringLength(20)]
        public string Office { get; set; }

        public int? Age { get; set; }

        public int? Salary { get; set; }
    }
}
