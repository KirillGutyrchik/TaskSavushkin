using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TaskSavushkin
{
    public interface IDevice
    {
        void EditName(string newName);

        void EditPrice(UInt64 newPrice);

        string GetName();

        UInt64 GetPrice();

        string GetTypeName();

        void AddProperty(string property, string value);

    }





    abstract class Device : IDevice
    {

        public Device(string type)
        {
            Type = type;

            Properties = new Dictionary<string, string>();
        }


        public void EditName(string newName)
        {
            Name = newName;
        }

        public void EditPrice(UInt64 newPrice)
        {
            Price = newPrice;
        }

        public string GetName()
        {
            return Name;
        }

        public UInt64 GetPrice()
        {
            return Price;
        }

        public string GetTypeName()
        {
            return Type;
        }

        public void AddProperty(string property, string value)
        {
            if(Properties.ContainsKey(property) == false) 
                Properties.Add(property, value);
        }


        public static IDevice getObject(Type type)
        {
            return (IDevice)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }


        public static Func<string> getMethodTypeName(Type type)
        {
            var lambda =
                    Expression.Lambda<Func<string>>(
                        Expression.Call(type.GetMethod("SGetTypeName"))
                    );
            return lambda.Compile();
        }



        //--------------------------------------------------
        private string Name { get; set; }

        private UInt64 Price { get; set; }

        private string Type { get; set; }

        private Dictionary<string, string> Properties { get; set; }
    }

}
