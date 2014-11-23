using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LiquidPlanner
{
    public class LiquidPlanner
    {
        public string Hostname { get; set; }

        private String _password;

        public String Username { get; set; }
        public String Password { get { return null; } set { _password = value; } }
        public Int32 WorkspaceId { get; set; }

        public LiquidPlanner(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        private LpResponse request(String verb, String url, Object data)
        {
            HttpWebRequest request;
            WebResponse response;
            String uri;
            LpResponse lp_response;

            uri = "https://app.liquidplanner.com/api" + url;

            request = WebRequest.Create(uri) as HttpWebRequest;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = verb;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers.Set("Authorization", Convert.ToBase64String(Encoding.ASCII.GetBytes(this.Username + ":" + this._password)));

            if (null != data)
            {
                request.ContentType = "application/json";
                String jsonPayload = JsonConvert.SerializeObject(data);
                byte[] jsonPayloadByteArray = Encoding.ASCII.GetBytes(jsonPayload.ToCharArray());
                request.GetRequestStream().Write(jsonPayloadByteArray, 0, jsonPayloadByteArray.Length);
            }


            lp_response = new LpResponse();
            try
            {
                response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                lp_response.response = reader.ReadToEnd();
                //Console.WriteLine(lp_response.response);

            }
            catch (Exception e)
            {
                lp_response.error = e;
            }
            return lp_response;
        }

        public LpResponse get(String url)
        {
            return request("GET", url, null);
        }
        public LpResponse post(String url, Object data)
        {
            return request("POST", url, data);
        }
        public LpResponse put(String url, Object data)
        {
            return request("PUT", url, data);
        }

        public t GetObject<t>(LpResponse response)
        {
            if (null != response.error)
                throw response.error;
            return JsonConvert.DeserializeObject<t>(response.response);
        }

        public Member GetAccount()
        {
            return GetObject<Member>(get("/account"));
        }
        
        public Package GetPackage()
        {
            return GetObject<Package>(get("/workspaces/" + this.WorkspaceId + "/treeitems/18172878/?depth=-1&leaves=true&include=checklist_items"));
        }
    }
}
