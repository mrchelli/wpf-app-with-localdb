using System;
using System.Collections.Generic;
using System.Linq;

public class DomainViewModel
{
    DomainDb _db = new DomainDb();
    public DomainViewModel()
    {
        AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
        Domain = _db.Domain.ToList();
    }
    public IList<Domain> Domain { get; set; }
    public IList<OU> OU { get; set; }
}
