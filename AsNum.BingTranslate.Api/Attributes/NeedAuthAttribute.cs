using AsNum.BingTranslate.Api.Handlers;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsNum.BingTranslate.Api.Attributes {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NeedAuthAttribute : HandlerAttribute {

        public override ICallHandler CreateHandler(IUnityContainer container) {
            return new NeedAuthHandler();
        }


    }
}
