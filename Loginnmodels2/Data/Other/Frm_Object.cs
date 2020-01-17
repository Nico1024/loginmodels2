using System;
namespace Loginnmodels2.Data
{
    public class Frm_Object<T>
    {
        T _value;

        public Frm_Object(T g)
        {
            _value = g;
        }
    }
}
