using AsNum.BingTranslate.Api.Attributes;
using AsNum.Common.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AsNum.Common.Extends;

namespace AsNum.BingTranslate.Api.Methods {


    /// <summary>
    /// 
    /// <remarks>
    /// https://msdn.microsoft.com/en-us/library/ff512420.aspx
    /// </remarks>
    /// </summary>
    public class Speak : MethodBase<byte[]> {
        public override string MethodName {
            get {
                return "Speak";
            }
        }

        [Param("text", Required = true)]
        public string Text {
            get;
            set;
        }

        [Param("language", Required = true)]
        public string Lang {
            get;
            set;
        }

        [EnumParam("format", EnumUseKeyOrValue.Key)]
        public Formats? Format {
            get;
            set;
        }

        [EnumParam("options", EnumUseKeyOrValue.Key)]
        public Qualities? Quality {
            get;
            set;
        }



        public enum Formats {
            [SpecifyKeyValue(Key = "audio/wav")]
            Wav,

            [SpecifyKeyValue(Key = "audio/mp3")]
            Mp3
        }

        public enum Qualities {
            [SpecifyKeyValue(Key = "MaxQuality")]
            Max,

            [SpecifyKeyValue(Key = "MinSize")]
            Min
        }

        internal override string GetResult(ApiClient client) {
            return "";
        }

        public override byte[] Execute(ApiClient client) {
            var url = client.GetApiUrl(this);
            var dic = this.GetParams();
            foreach (var kv in dic) {
                url = url.SetUrlKeyValue(kv.Key, kv.Value);
            }

            WebClient c = new WebClient();
            c.Headers.Add(HttpRequestHeader.Authorization, string.Format("Bearer {0}", client.Token.Token));
            return c.DownloadData(url);
        }
    }
}
