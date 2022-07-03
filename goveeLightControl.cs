using System.Net;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

public class CPHInline
{

    public bool Brightness()
    {
        string api = CPH.GetGlobalVar<String>("goveeApiKeyGlobal", true);
        string mac = args["macAddress"].ToString();
        string modelNum = args["modelNumber"].ToString();
        int brightnessValue = Convert.ToInt32(args["brightness"]);
        using (HttpClient client = new HttpClient())
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://developer-api.govee.com/v1/devices/control");
            webRequest.ContentType = "application/json";
            webRequest.Method = "PUT";
            webRequest.Headers.Add("Govee-API-Key", api);
            var serializer = new JsonSerializer();
            TextWriter json = new StringWriter();
            serializer.Serialize(json, new
            {
            device = mac, model = modelNum, cmd = new
            {
            name = "brightness", value = brightnessValue
            }
            }

            );
            //string temp2 = json.ToString();
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

    public bool Color()
    {
        int red = Convert.ToInt32(args["lights.color.r"]);
        int green = Convert.ToInt32(args["lights.color.g"]);
        int blue = Convert.ToInt32(args["lights.color.b"]);
        string api = CPH.GetGlobalVar<String>("goveeApiKeyGlobal", true);
        string mac = args["macAddress"].ToString();
        string modelNum = args["modelNumber"].ToString();
        using (HttpClient client = new HttpClient())
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://developer-api.govee.com/v1/devices/control");
            webRequest.ContentType = "application/json";
            webRequest.Method = "PUT";
            webRequest.Headers.Add("Govee-API-Key", api);
            var serializer = new JsonSerializer();
            TextWriter json = new StringWriter();
            serializer.Serialize(json, new
            {
            device = mac, model = modelNum, cmd = new
            {
            name = "color", value = new
            {
            r = red, g = green, b = blue
            }
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

    public bool ColorTemp()
    {
        string api = CPH.GetGlobalVar<String>("goveeApiKeyGlobal", true);
        string mac = args["macAddress"].ToString();
        string modelNum = args["modelNumber"].ToString();
        int colorTempValue = Convert.ToInt32(args["colorTemp"]);
        using (HttpClient client = new HttpClient())
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://developer-api.govee.com/v1/devices/control");
            webRequest.ContentType = "application/json";
            webRequest.Method = "PUT";
            webRequest.Headers.Add("Govee-API-Key", api);
            var serializer = new JsonSerializer();
            TextWriter json = new StringWriter();
            serializer.Serialize(json, new
            {
            device = mac, model = modelNum, cmd = new
            {
            name = "colorTem", value = colorTempValue
            }
            }

            );
            //string temp2 = json.ToString();
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

    public bool OnOff()
    {
        string api = CPH.GetGlobalVar<String>("goveeApiKeyGlobal", true);
        string mac = args["macAddress"].ToString();
        string modelNum = args["modelNumber"].ToString();
        string lightStatus = args["lightBool"].ToString();
        using (HttpClient client = new HttpClient())
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("https://developer-api.govee.com/v1/devices/control");
            webRequest.ContentType = "application/json";
            webRequest.Method = "PUT";
            webRequest.Headers.Add("Govee-API-Key", api);
            var serializer = new JsonSerializer();
            TextWriter json = new StringWriter();
            serializer.Serialize(json, new
            {
            device = mac, model = modelNum, cmd = new
            {
            name = "turn", value = lightStatus
            }
            }

            );
            //string temp2 = json.ToString();
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
