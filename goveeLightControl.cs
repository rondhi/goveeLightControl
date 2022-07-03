//Code by psxboy#2954 on Discord
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

public class CPHInline
{
    public bool Execute()
    {
        using (HttpClient client = new HttpClient())
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://developer-api.govee.com/v1/devices/control");
            webRequest.ContentType = "application/json";
            webRequest.Method = "PUT";
            webRequest.Headers.Add("Govee-API-Key", "api-key");
            var serializer = new JsonSerializer();
            TextWriter json = new StringWriter();
            serializer.Serialize(json, new
            {
            device = "MACAddr", model = "H6195", cmd = new
            {
            name = "turn", value = "on"
            }
            }

            );
            
            using (var streamWriter = new System.IO.StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)webRequest.GetResponse();

            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                //CPH.SendMessage(responseText);
            }
        }

        return true;
    }
}
