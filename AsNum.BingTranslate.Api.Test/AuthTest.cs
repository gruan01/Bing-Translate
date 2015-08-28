using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsNum.BingTranslate.Api.Methods;
using System.Media;
using System.IO;
using System.Configuration;

namespace AsNum.BingTranslate.Api.Test {
    [TestClass]
    public class AuthTest {

        [TestInitialize]
        public void Init() {
            var clientID = ConfigurationManager.AppSettings.Get("ClientID");
            var secretCode = ConfigurationManager.AppSettings.Get("SecretCode");

            ApiClient.Init(clientID, secretCode);
        }


        [TestMethod]
        public void TestMethod1() {

            var method = new Translate() {
                To = "en",
                Text = "建议开发者使用如下方法进行修复"
            };
            var result = ApiClient.ExecuteWrap(method);
        }

        [TestMethod]
        public void SupportSpeakLang() {
            var method = new GetLanguagesForSpeak();
            var result = ApiClient.ExecuteWrap(method);
        }

        [TestMethod]
        public void SupportTranslateLang() {
            var method = new GetLanguagesForTranslate();
            var result = ApiClient.ExecuteWrap(method);
        }

        [TestMethod]
        public void Speek() {
            var method = new Speak() {
                Text = "Cron 表达式分为7个子表达式",
                Lang = "zh-CN",
                Quality = AsNum.BingTranslate.Api.Methods.Speak.Qualities.Max
            };

            var result = ApiClient.ExecuteWrap(method);
            using (var stm = new MemoryStream(result))
            using (var player = new SoundPlayer(stm)) {
                player.Play();
            }
        }
    }
}
