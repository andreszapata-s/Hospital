using Hospital.BL.Data;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

namespace University
{
    public partial class Startup
    {
        public void ConfigurationAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(HospitalContext.Create);
        }
    }
}
