using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsNum.BingTranslate.Api.Attributes {

    /// <summary>
    /// 枚举参数,指定 Key Value
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class SpecifyKeyValueAttribute : Attribute {

        public string Key {
            get;
            set;
        }

        public int Value {
            get;
            set;
        }

    }
}
