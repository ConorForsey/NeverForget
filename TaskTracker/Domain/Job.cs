using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Domain
{
    public class Job
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
