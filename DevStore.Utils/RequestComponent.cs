using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Utils
{
    public class RequestComponent
    {

        public string RequestUrl(string urlRequest, string content, string contentType, string requestMethod, IDictionary<string, string> headerKeys = null)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(urlRequest);
            string retorno = "";
            try
            {


                httpRequest.ContentType = contentType; //"text/json";
                httpRequest.Method = requestMethod;
                httpRequest.Timeout = 2000000;
                foreach (KeyValuePair<string, string> item in headerKeys)
                {
                    httpRequest.Headers.Add(item.Key, item.Value);
                }

                ServicePointManager.DefaultConnectionLimit = 60;
                ServicePointManager.Expect100Continue = false;

                if (!string.IsNullOrEmpty(content))
                {
                    byte[] bufferInfo = new byte[System.Text.Encoding.ASCII.GetBytes(content).Length];
                    bufferInfo = System.Text.Encoding.ASCII.GetBytes(content);

                    httpRequest.ContentLength = bufferInfo.Length;
                    Stream writer = httpRequest.GetRequestStream();

                    for (int i = 0; i < httpRequest.ContentLength; i++)
                    {
                        writer.WriteByte(bufferInfo[i]);
                    }
                }

                HttpWebResponse resp = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader streamResp = new StreamReader(resp.GetResponseStream());


                if (resp.StatusCode.ToString() != "200")
                {
                    throw new Exception("Bad Request");
                }
                retorno = streamResp.ReadToEnd();
            }
            catch (Exception e)
            {
                return "{ 'error':'bad request' }";
            }
            return retorno;
        }
    }
}
