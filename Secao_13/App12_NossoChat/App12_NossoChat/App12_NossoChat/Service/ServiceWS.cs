using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using App12_NossoChat.Model;
using Newtonsoft.Json;

namespace App12_NossoChat.Service
{
    public class ServiceWS
    {
        private const string EnderecoBase = "http://ws.spacedu.com.br/xf2018/rest/api";

        public static Usuario GetUsuario(Usuario usuario)
        {
            string url = string.Format("{0}/usuario", EnderecoBase);
            /**
             * QueryString
             * StringContent praram = new StringContent(string.Format("?nome={0}&password={1}", usuario.nome, usuario.password));
             */

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("nome", usuario.nome),
                new KeyValuePair<string, string>("password", usuario.password)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(url, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    return JsonConvert.DeserializeObject<Usuario>(conteudo);
                }
            }

            return null;
        }

        public static List<Chat> GetChats()
        {
            string url = string.Format("{0}/chats", EnderecoBase);
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(url).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Chat> chats = JsonConvert.DeserializeObject<List<Chat>>(conteudo);
                    return chats;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public static bool InsertChat(Chat chat)
        {
            string url = string.Format("{0}/chat", EnderecoBase);

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("nome", chat.nome)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(url, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RenomearChat(Chat chat)
        {
            string url = string.Format("{0}/chat/{1}", EnderecoBase, chat.id);

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("nome", chat.nome)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PutAsync(url, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteChat(Chat chat)
        {
            string url = string.Format("{0}/chats/delete/{1}", EnderecoBase, chat.id);
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(url).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Mensagem> GetMensagensChat(Chat chat)
        {
            string url = string.Format("{0}/chats/{1}/msg", EnderecoBase, chat.id);
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(url).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Mensagem> mensagens = JsonConvert.DeserializeObject<List<Mensagem>>(conteudo);
                    return mensagens;
                }
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        public static bool InsertMensagem(Mensagem mensagem)
        {
            string url = string.Format("{0}/chat/{1}/msg", EnderecoBase, mensagem.id_chat);

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("mensagem", mensagem.mensagem),
                new KeyValuePair<string, string>("id_usuario", mensagem.id_usuario.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(url, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteMensagem(Mensagem mensagem)
        {
            string url = string.Format("{0}/chat/{1}/delete/{2}", EnderecoBase, mensagem.id_chat, mensagem.id);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(url).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}