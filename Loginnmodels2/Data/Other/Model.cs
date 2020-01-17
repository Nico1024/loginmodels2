using System;
namespace Loginnmodels2.Data
{
    public class Model
    {
        public System.Guid instance_id;

        public Model()
        {
            instance_id = System.Guid.NewGuid();
        }
    }
}
