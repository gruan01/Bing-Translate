using AsNum.BingTranslate.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsNum.BingTranslate.Api.Methods {
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/ff512421.aspx
    /// </summary>
    public class Translate : MethodBase<string> {
        public override string MethodName {
            get {
                return "Translate";
            }
        }

        public override HttpMethods RequestType {
            get {
                return HttpMethods.Get;
            }
        }

        [Param("text")]
        public string Text {
            get;
            set;
        }

        [Param("from")]
        public string From {
            get;
            set;
        }


        [Param("to")]
        public string To {
            get;
            set;
        }
    }
}
