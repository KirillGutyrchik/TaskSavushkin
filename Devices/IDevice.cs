using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TaskSavushkin
{
    interface IDevice
    {
        void setName();

        
        void addProperty(string property, string value);

    }





    abstract class Device : IDevice
    {
        public void setName()
        {

        }

        
        public void addProperty(string property, string value)
        {
            Properties.Add(property, value);
        }

        
        public Device()
        {
            Properties = new Dictionary<string, string>();
        }

        
        public static IDevice getObject(Type type)
        {
            return (IDevice)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }

        
        public static Func<string> getMethodTypeName(Type type)
        {
            var lambda =
                    Expression.Lambda<Func<string>>(
                        Expression.Call(type.GetMethod("getTypeName"))
                    );
            return lambda.Compile();
        }



        //---------------------------------------------------
        private UInt64 ID { get;  }
        private string Type { get; }
        private string Name { get; }
        private Dictionary<string, string> Properties { get; }

    }

}
