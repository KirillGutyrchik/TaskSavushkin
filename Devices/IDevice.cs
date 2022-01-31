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
        string UINameType { get; }

        string ExternalNameType { get; }

        double Price { get; set; }

        string Name { get; set; }

        Dictionary<string, string> DefaultProperties { get; }
        Dictionary<string,string> Properties { get; }



        bool AddOrUpdateProperty(string property, string value);
        bool RemoveProperty(string property);
    }





    abstract class Device : IDevice
    {       
        private string _UINameType { get; set; }
        private string _ExternalNameType { get; set; }

        private string _Name { get; set; }
        private double _Price { get; set; }
        private Dictionary<string, string> _DefaultProperties { get; set; }
        private Dictionary<string, string> _Properties { get; set; }


        public string UINameType
        {
            get { return _UINameType; }
        }

        public string ExternalNameType
        {
            get { return _ExternalNameType; }
        }

        public string Name 
        { 
            get { return _Name; } 
            set { _Name = value; }
        }

        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public Dictionary<string, string> DefaultProperties
        {
            get { return _DefaultProperties; }
        }

        public Dictionary<string,string> Properties
        {
            get { return _Properties; }
        }

        public Device(string uiNameType, string externalNameType, Dictionary<string, string> defaultProperties)
        {
            _UINameType = uiNameType;
            _ExternalNameType = externalNameType;

            _DefaultProperties = defaultProperties;
            _Properties = new Dictionary<string, string>();
        }



        public bool AddOrUpdateProperty(string property, string value)
        {

            if (property != null && property != string.Empty)
            {
                if (DefaultProperties.ContainsKey(property))
                {
                    DefaultProperties[property] = value;
                }
                else Properties[property] = value;

                return true;
            }
            return false;
        }

        public bool RemoveProperty(string property)
        {
            return _Properties.Remove(property);
        }

        public static IDevice GetObject(Type type)
        {
            return (IDevice)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }

        public static (string, string) GetUINameType(Type type)
        {
            var constExpression = Expression.Constant(GetObject(type));

            return (Expression.Lambda<Func<string>>(
                        Expression.PropertyOrField(
                            constExpression,
                            "UINameType")
                    ).Compile()(), 
                    Expression.Lambda<Func<string>>(
                        Expression.PropertyOrField(
                            constExpression,
                            "ExternalNameType")
                    ).Compile()());
        }

    }

}
