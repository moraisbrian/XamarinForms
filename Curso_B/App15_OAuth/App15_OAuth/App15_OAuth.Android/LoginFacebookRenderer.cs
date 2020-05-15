using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Newtonsoft.Json;
using Xamarin.Auth;

[assembly:ExportRenderer(typeof(App15_OAuth.Views.LoginFacebook), typeof(App15_OAuth.Droid.LoginFacebookRenderer))]
namespace App15_OAuth.Droid
{
    public class LoginFacebookRenderer : PageRenderer
    {
        public LoginFacebookRenderer(Context context) : base(context)
        {
            var auth = new OAuth2Authenticator(
                clientId: "000000000000000",
                scope: "email", // Permissões
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
            );

            auth.Completed += async (sender, args) =>
            {
                if (args.IsAuthenticated)
                {
                    var token = args.Account.Properties["access_token"].ToString();

                    var requisicao = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, args.Account);
                    var resposta = await requisicao.GetResponseAsync();

                    var obj = Newtonsoft.Json.Linq.JObject.Parse(resposta.GetResponseText());
                    var nome = obj["name"].ToString().Replace("\"", "");
                    var email = obj["email"].ToString().Replace("\"", "");

                    App.NavegarParaInicial(nome, email);
                }
                else
                {
                    App.NavegarParaInicial("Login rejeitado");
                }
            };

            var activity = this.Context as Activity;
            activity.StartActivity(auth.GetUI(activity));
        }
    }
}