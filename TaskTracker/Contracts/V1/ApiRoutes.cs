using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Contracts.V1
{
    public class ApiRoutes
    {
        public const string root = "api";

        public const string version = "v1";

        public const string directory = root + "/" + version;

        public static class Jobs
        {
            public const string GetAll = directory + "/jobs";

            public const string Get = directory + "/jobs/{jobId}";

            public const string Create = directory + "/jobs";

            public const string Update = directory + "/jobs/{jobId}";

            public const string Delete = directory + "/jobs/{jobId}";
        } 
    }
}
