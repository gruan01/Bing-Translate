using System;
using System.Collections.Generic;
using System.Linq;

namespace AsNum.BingTranslate.Api.Attributes {

    public enum EnumUseKeyOrValue {
        Key,
        Value
    }

    public class EnumParamAttribute : ParamAttribute {

        private EnumUseKeyOrValue Use;

        public EnumParamAttribute(string name, EnumUseKeyOrValue use)
            : base(name) {

            this.Use = use;
        }

        public override Dictionary<string, string> GetParams(object obj, System.Reflection.PropertyInfo p) {
            var value = p.GetValue(obj, null);
            if (value != null) {
                var skv = value.GetType()
                        .GetField(value.ToString())
                        .GetCustomAttributes(false)
                        .OfType<SpecifyKeyValueAttribute>().FirstOrDefault();

                if (skv != null) {
                    value = this.Use == EnumUseKeyOrValue.Key ? (object)skv.Key : skv.Value;
                } else {
                    value = this.Use == EnumUseKeyOrValue.Key ? Enum.GetName(obj.GetType(), obj) : value;
                }
            }


            if (value == null && this.Required)
                return new Dictionary<string, string>(){
                    {this.Name, ""}
                };
            else if (value == null && !this.Required)
                return null;
            else
                return new Dictionary<string, string>(){
                    {this.Name, value.ToString()}
                };
        }

    }
}
