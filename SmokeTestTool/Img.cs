using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmokeTestTool
{
    class Img
    {
        public string sourceDomain { get; set; }
        public List<string> allSourceImages { get; set; }
        public void GetAllSourceImages(string urlAddress, ref TreeNode Result)
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
            htmlSource = htmlSource.Substring(htmlSource.IndexOf("<body>"), htmlSource.IndexOf("</body>") - htmlSource.IndexOf("<body>"));
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
            MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;
                if (href != "/" && !allSourceImages.Contains(href) && !href.Contains("mail"))
                {
                    if (href.ToLower().Contains("aspnet") || href.ToLower().Contains("google")
                        || href.ToLower().Contains("facebook"))
                    {
                        continue;
                    }
                    else
                    {
                        TreeNode node = new TreeNode(href);
                        
                        Result.Nodes.Add(node);
                        allSourceImages.Add(href);
                    }

                }
            }
        }
    }
}
