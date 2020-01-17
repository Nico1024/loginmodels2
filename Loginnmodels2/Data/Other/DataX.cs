using System;
using System.ComponentModel.DataAnnotations;

namespace Loginnmodels2.Data
{
    public class DataX
    {
        public string Name { get; set; } = "Jane Doe";
        public string Phone { get; set; } = "123456789";
        public string Address { get; set; } = "The Street";

        [Required] public int Sequence { get; set; } = 1;
    }

    //public class Startup
    //{
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //    }

    //    public void Configure(IComponentsApplicationBuilder app)
    //    {
    //        app.AddComponent<App>("app");
    //    }
    //}
}


