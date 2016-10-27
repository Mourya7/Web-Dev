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
    public partial class Research_details : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        public Research_details(string name, string type)
        {
            InitializeComponent();

            if (type == "faculty")
            {
                string jsonResDetails = rj.getJSON("/research/byFaculty/username=" + name);
                ByFaculty research = JToken.Parse(jsonResDetails).ToObject<ByFaculty>();
                txt_researchdetails.Text = "";
                foreach (string details in research.citations)
                {
                    
                    txt_researchdetails.AppendText(Environment.NewLine+details+Environment.NewLine);
                }
            }

            else
            {
                string jsonResDetails = rj.getJSON("/research/byInterestArea/areaName=" + name);
                ByInterestArea research = JToken.Parse(jsonResDetails).ToObject<ByInterestArea>();
                txt_researchdetails.Text = "";
                foreach (string details in research.citations)
                {
                    
                    txt_researchdetails.AppendText(Environment.NewLine+details+Environment.NewLine);
                }
            }
        }
    }
}
