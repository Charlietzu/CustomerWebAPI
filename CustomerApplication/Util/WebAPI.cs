using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication.Util
{
    public class WebAPI
    {

        public static string URL = "https://localhost:44370/api/Customer";
        public static string TOKEN = "123uiy706059hgj";
        public static string GetRequest(string method, string parameter)
        {
            string urlParams = "";
            if (method == null && parameter != null)
            {
                urlParams = URL + parameter;
            }
            else if (parameter == null && method != null)
            {
                urlParams = URL + method;
            }
            else if (method != null && parameter != null)
            {
                urlParams = URL + method + "/" + parameter;
            }
            else
            {
                urlParams = URL;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlParams);
            request.Headers.Add("Token", TOKEN);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        public static string PostRequest(string method, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create($"{URL}/{method}");
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "POST";
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public static string PutRequest(string method, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create($"{URL}/{method}");
            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "PUT";
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

        public static string DeleteRequest(string method, string parameter)
        {
            var request = (HttpWebRequest)WebRequest.Create($"{URL}/{method}/{parameter}");
            request.Method = "DELETE";
            request.Headers.Add("Token", TOKEN);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

    }
}
