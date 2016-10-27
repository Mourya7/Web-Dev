using Newtonsoft.Json.Linq;
using RESTUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3_Mourya
{
    public partial class Minor_details : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        public Minor_details(string UgMinor)
        {
            InitializeComponent();
            string jsonMinor = rj.getJSON("/minors/UgMinors/name=" + UgMinor);
            string[] minorCourses = new string[8];
            UgMinor minor = JToken.Parse(jsonMinor).ToObject<UgMinor>();
            txt_minordetails.AppendText(minor.title + Environment.NewLine);
            txt_minordetails.AppendText(minor.description+Environment.NewLine);
            txt_minordetails.AppendText(Environment.NewLine+"Courses:" + Environment.NewLine);
            int count = 0;
            foreach (String course in minor.courses)
            {
                minorCourses[count] = minor.courses[count];
                count++;
            }
            count = 0;
            while(count<minorCourses.Length)
            {
                txt_minordetails.AppendText(minorCourses[count]+Environment.NewLine);
                count++;
            }
        }
    }
}
