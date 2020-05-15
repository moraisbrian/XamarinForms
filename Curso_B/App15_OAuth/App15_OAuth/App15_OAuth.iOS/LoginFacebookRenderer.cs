using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Newtonsoft.Json;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;

[assembly: ExportRenderer(typeof(App15_OAuth.Views.LoginFacebook), typeof(App15_OAuth.iOS.LoginFacebookRenderer))]
namespace App15_OAuth.iOS
{
    public class LoginFacebookRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var auth = new OAuth2Authenticator(
                clientId: "000000000000000",
                scope: "email", // Permissões
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
            );

            auth.Completed += async (sender, args) =>
            {
                DismissViewController(true, null);
                if (args.IsAuthenticated)
                {
                    var token = args.Account.Properties["access_token"].ToString();

                    var requisicao = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, args.Account);
                    var resposta = await requisicao.GetResponseAsync();

                    var obj = JObject.Parse(resposta.GetResponseText());
                    var nome = obj["name"].ToString().Replace("\"", "");
                    var email = obj["email"].ToString().Replace("\"", "");

                    App.NavegarParaInicial(nome, email);
                }
                else
                {
                    App.NavegarParaInicial("Login rejeitado");
                }
            };

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}