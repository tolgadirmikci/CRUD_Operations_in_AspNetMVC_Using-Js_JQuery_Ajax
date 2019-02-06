namespace MVCCRUD_DATATABLE.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MVCMODEL : DbContext
    {
        public MVCMODEL()
            : base("name=MVCMODEL")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
