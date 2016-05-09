using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace SmokeTestTool
{
    public partial class Form1 : Form
    {
        List<string> allSourceLinks = new List<string>();
        ImageList myImageList = new ImageList();
        string sourceDomain = "http://localhost:15898/";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Result1.Nodes.Clear();
            Links s1 = new Links();
            s1.sourceDomain = txtSourceUrl.Text;
            s1.allSourceLinks = new List<string>();
            Result1.ImageList = myImageList;
            s1.GetAllSourceLinks(txtSourceUrl.Text, ref Result1);

            Result2.Nodes.Clear();
            Links s2 = new Links();
            s2.sourceDomain = txtDestUrl.Text;
            s2.allSourceLinks = new List<string>();
            s2.GetAllSourceLinks(txtDestUrl.Text, ref Result2);
           
        }
    }
}
