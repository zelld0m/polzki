using System;
using System.Net;
using System.Configuration;
using System.IO;
using System.Collections.Generic;

namespace Exam.Service
{
    public static class ApiService
    {

        public static string Get(string webAddr)
        {
            string responseText = string.Empty;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = streamReader.ReadToEnd();
                }

            }
            catch (WebException ex)
            {
             }
            return responseText;
        }

        public static string Post(string webAddr, string json)
        {  
            string responseText = string.Empty;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = streamReader.ReadToEnd();

                }
            }
            catch (WebException ex)
            {
                responseText = "failed";
               
            }

            return responseText;
        }
    }
}