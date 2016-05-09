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
    class Links
    {
        public string sourceDomain { get; set; }
        public List<string> allSourceLinks { get; set; }
        public void GetAllSourceLinks(string urlAddress,ref TreeView Result)
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
                        FetchSourceLinksFromSource(data,ref Result);

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

        private void FetchSourceLinksFromSource(string htmlSource, ref TreeView Result)
        {
            htmlSource = htmlSource.Substring(htmlSource.IndexOf("<body>"), htmlSource.IndexOf("</body>") - htmlSource.IndexOf("<body>"));
            string regexImgSrc = @"<a[^>]*?href\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
            MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;
                if (href != "/" && !allSourceLinks.Contains(href) && !href.Contains("mail"))
                {
                    if (href.ToLower().Contains("aspnet") || href.ToLower().Contains("google")
                        || href.ToLower().Contains("facebook") || href.ToLower().Contains("microsoft") || href.ToLower().Contains("asp.net"))
                    {
                        continue;
                    }
                    else
                    {
                        TreeNode node = new TreeNode(href);

                        TreeNode image = new TreeNode("Images");
                        TreeNode video = new TreeNode("Videos");
                        TreeNode span = new TreeNode("Spans");
                        TreeNode ul = new TreeNode("ul");
                        TreeNode div = new TreeNode("Divs");

                        Img img = new Img();
                        img.sourceDomain = this.sourceDomain;
                        img.allSourceImages = new List<string>();
                        img.GetAllSourceImages(href, ref image);
                        image.Text = string.Format("{0}({1})", image.Text, image.Nodes.Count);
                        node.Nodes.Add(image);


                        Span spn = new Span();
                        spn.sourceDomain = this.sourceDomain;
                        spn.allSourceSpans = new List<string>();
                        spn.GetAllSourceSpans(href, ref span);
                        span.Text = string.Format("{0}({1})", span.Text, span.Nodes.Count);
                        node.Nodes.Add(span);

                        Ul Ul = new Ul();
                        Ul.sourceDomain = this.sourceDomain;
                        Ul.allSourceUls = new List<string>();
                        Ul.GetAllSourceUls(href, ref ul);
                        ul.Text = string.Format("{0}({1})", ul.Text, ul.Nodes.Count);
                        node.Nodes.Add(ul);

                        Video videos = new Video();
                        videos.sourceDomain = this.sourceDomain;
                        videos.allSourceVideos = new List<string>();
                        videos.GetAllSourceVideos(href, ref video);
                        video.Text = string.Format("{0}({1})", video.Text, video.Nodes.Count);
                        node.Nodes.Add(video);

                        Div divs = new Div();
                        divs.sourceDomain = this.sourceDomain;
                        divs.allSourceDivs = new List<string>();
                        divs.GetAllSourceDivs(href, ref div);
                        div.Text = string.Format("{0}({1})", div.Text, div.Nodes.Count);
                        node.Nodes.Add(div);


                        Result.Nodes.Add(node);
                        allSourceLinks.Add(href);
                        GetAllSourceLinks(href,ref Result);
                    }

                }
            }
        }
    }
}
