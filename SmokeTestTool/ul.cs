using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SmokeTestTool
{
    class Ul
    {
        public string sourceDomain { get; set; }
        public List<string> allSourceUls { get; set; }
        public void GetAllSourceUls(string urlAddress, ref TreeNode Result)
        {
            if (urlAddress.StartsWith("/"))
            {
                urlAddress = string.Format("{0}{1}", sourceDomain, urlAddress.Remove(0, 1));
            }

            if (urlAddress.Contains(sourceDomain))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = null;

                        if (response.CharacterSet == null)
                        {
                            readStream = new StreamReader(receiveStream);
                        }
                        else
                        {
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }

                        string data = readStream.ReadToEnd();
                        FetchSourceLinksFromSource(data, ref Result);

                        response.Close();
                        readStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }

            }

        }

        private void FetchSourceLinksFromSource(string htmlSource, ref TreeNode Result)
        {

            htmlSource = htmlSource.Substring(htmlSource.IndexOf("<body>"), htmlSource.IndexOf("</body>")- htmlSource.IndexOf("<body>"));

            List<string> listOfSpans = htmlSource.ExtractFromString("<ul", "</ul>");

            foreach (var href in listOfSpans)
            {
                var hrefr = href.Remove(0, href.IndexOf(">")).Replace(" ","");
                TreeNode node = new TreeNode(hrefr);
                Result.Nodes.Add(node);
                allSourceUls.Add(hrefr);
            }
        }
    }
}
