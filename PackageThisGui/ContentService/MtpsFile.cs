using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Xml;


// The MTPS Service via SOAP is far from perfect.
// Often the easiest way to get missing data is to download the mtps file and parse it.
// It's a Hack. If you can fix the real problems be my guest.

namespace PackageThis.MtpsFiles
{
    static public class MtpsFile
    {
        static public string shortId = "";
        static public string guid = "";
        //static public string xml = "";


        public static void Test(string contentId, string version, string locale)
        {
            //mtps page of doc http://services.mtps.microsoft.com/serviceapi/content/ms533050/en-us;vs.85

            String url = String.Format("http://services.mtps.microsoft.com/serviceapi/content/{0}/{1};{2}",
                    contentId, locale, version);

            string result = GetWebFile(url);

            /*
              <span id="guid" class="guid">0cc23484-7f8a-421d-b10e-cdf2c37ba59b</span> 
              <span id="shortid" class="shortid">cc294537</span> 
            */

            shortId = "";
            guid = "";

            WebRequest request = WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream dataStream = request.GetResponse().GetResponseStream())
                {
                    using (XmlTextReader reader = new XmlTextReader(dataStream))
                    {
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element: // The node is an element.
                                    if (reader.Name == "span" && reader.HasAttributes )
                                    {
                                        if (reader.GetAttribute("id") == "shortid")
                                        {
                                            reader.Read();
                                            Console.WriteLine(">>" + reader.Value);
                                        }
                                        else if (reader.GetAttribute("id") == "guid")
                                        {
                                            reader.Read();
                                            Console.WriteLine(">>" + reader.Value);
                                        }
                                    }
                                    break;
                                case XmlNodeType.Text: //Display the text in each element.
                                    Console.WriteLine(reader.Value);
                                    break;
                                case XmlNodeType.EndElement: //Display the end of the element.
                                    Console.Write("</" + reader.Name);
                                    Console.WriteLine(">");
                                    break;
                            }
                        }
                    }
                }
            }



        }



        #region Read web

        public static Stream ReadStream(string url)
        {
            Stream dataStream = null;
            try
            {
                WebRequest request = WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    dataStream = request.GetResponse().GetResponseStream();
                }
            }
            catch
            {
            }
            return dataStream;
        }

        /*
         * Read xml mpts file from the server (file id = contentId/version/locale). 
         * contentId could be ShortId or GUID (anything that works in an mpts URL.
         * The file is scanned for the following data...
         * 
              <span id="guid" class="guid">0cc23484-7f8a-421d-b10e-cdf2c37ba59b</span> 
              <span id="shortid" class="shortid">cc294537</span> 
        */
        public static void ReadData(string contentId, string version, string locale)
        {
            //mtps page of doc http://services.mtps.microsoft.com/serviceapi/content/ms533050/en-us;vs.85

            String url = String.Format("http://services.mtps.microsoft.com/serviceapi/content/{0}/{1};{2}",
                    contentId, locale, version);

            shortId = "";
            guid = "";
            //xml = "";

            try
            {
                WebRequest request = WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream dataStream = request.GetResponse().GetResponseStream())
                    {
                        //debug
                        /*
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            xml = reader.ReadToEnd();
                        }
                        */

                        using (XmlTextReader reader = new XmlTextReader(dataStream))
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element)
                                {
                                    if (reader.Name == "span" && reader.HasAttributes)
                                    {
                                        if (reader.GetAttribute("id") == "shortid")
                                        {
                                            reader.Read(); //move to text after element
                                            shortId = reader.Value;
                                        }
                                        else if (reader.GetAttribute("id") == "guid")
                                        {
                                            reader.Read(); //move to text after element
                                            guid = reader.Value;
                                        }
                                    }
                                }

                                //Done?
                                if (shortId != "" && guid != "")
                                    break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }

        }

        // Download Web File as String
        public static string GetWebFile(string webUrl)
        {
            string returnXml = "";

            WebRequest request = WebRequest.Create(webUrl);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream dataStream = request.GetResponse().GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        returnXml = reader.ReadToEnd();
                    }
                }
            }

            return returnXml;
        }

        #endregion


    }
}
