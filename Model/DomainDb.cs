using System;
using System.Data.Entity;
using System.Linq;


public class DomainDb : DbContext
{
    public DomainDb() : base("name=DefaultConnection")
    {

    }

    public DbSet<Domain> Domain { get; set; }
    public DbSet<OU> OU { get; set; }
	
}
