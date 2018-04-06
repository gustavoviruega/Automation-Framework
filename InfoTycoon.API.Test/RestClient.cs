using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


public enum HttpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}

namespace InfoTycoon.API.Test
{
    public class RestClient
    {
        #region Properties
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }
        public string Header { get; set; }
        #endregion

        #region Constructors
        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            PostData = "";
            ContentType = "application/json";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            PostData = "";
            ContentType = "application/json";
        }
        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            PostData = "";
            ContentType = "application/json";
        }
        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            PostData = postData;
            ContentType = "application/json";
        }
        public RestClient(string endpoint, HttpVerb method, string postData, string contentType)
        {
            EndPoint = endpoint;
            Method = method;
            PostData = postData;
            ContentType = contentType;
        }
        #endregion

        #region Methods
        public string MakeRequestString()
        {
            try
            {
                return MakeRequestString("");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string MakeRequestString(string parameters)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

                request.Method = Method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;
                request.Headers["Authorization"] = Header;
                request.Timeout = 600000;

                if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
                {
                    var encoding = new UTF8Encoding();
                    var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                    request.ContentLength = bytes.Length;

                    using (var writeStream = request.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    return responseValue;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object MakeRequestJson()
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);

                request.Method = Method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;
                request.Timeout = 3600000;

                if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
                {
                    var encoding = new UTF8Encoding();
                    var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                    request.ContentLength = bytes.Length;

                    using (var writeStream = request.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    string text = "";
                    if (response != null)
                    {
                        var reader = new StreamReader(
                            response.GetResponseStream(),
                            Encoding.UTF8
                        );

                        using (reader)
                        {
                            text = reader.ReadToEnd();
                        }
                    }

                    JContainer result;
                    if (text != "")
                    {
                        if (text.StartsWith("["))
                        {
                            result = JArray.Parse(text);
                        }
                        else
                        {
                            result = JObject.Parse(text);
                        }
                    }
                    else
                    {
                        result = new JObject();
                    }

                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object ObtainToken()
        {
            try
            {
                EndPoint = "https://dev-m.infotycoon.com/token";
                Method = HttpVerb.POST;
                PostData = "grant_type=password&username=gviruega@velocitypartners.net&password=test_123";
                ContentType = "application/x-www-form-urlencoded";

                return MakeRequestJson();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }

}
