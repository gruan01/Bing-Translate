using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AsNum.BingTranslate.Api.Attributes {

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ParamAttribute : Attribute {

        public string Name {
            get;
            private set;
        }

        public bool Required {
            get;
            set;
        }

        public ParamAttribute(string name) {
            this.Name = name;
            this.Required = true;
        }

        public virtual Dictionary<string, string> GetParams(object obj, PropertyInfo p) {
            var value = p.GetValue(obj, null);
            if (value == null && this.Required)
                return new Dictionary<string, string>(){
                    {this.Name, ""}
                };
            else if (value == null && !this.Required)
                return null;
            else
                return new Dictionary<string, string>(){
                    {this.Name, p.GetValue(obj, null).ToString()}
                };
        }
    }
}
