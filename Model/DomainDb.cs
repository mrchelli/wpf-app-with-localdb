using System;
using System.Data.Entity;
using System.Linq;
using TestApplication;

public class DomainDb : DbContext
{
    public DomainDb() : base("name=DefaultConnection")
    {

    }

    public DbSet<Domain> Domain { get; set; }
	
}
