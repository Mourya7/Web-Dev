using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RESTUtil;
using Newtonsoft.Json.Linq;

namespace Project3_Mourya
{
    public partial class People_details : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        public People_details(string uName, string uType)
        {
            InitializeComponent();
            string jsonPeople = rj.getJSON("/people/" + uType + "/username=" + uName);
            
            if(uType == "faculty")
            {
                Faculty people = JToken.Parse(jsonPeople).ToObject<Faculty>();
                txt_peopledetails.Text = "";
                txt_peopledetails.AppendText(people.name+Environment.NewLine);
                txt_peopledetails.AppendText(people.title+ Environment.NewLine);
                txt_peopledetails.AppendText(people.interestArea + Environment.NewLine);
                txt_peopledetails.AppendText(people.phone + Environment.NewLine);
                txt_peopledetails.AppendText(people.email + Environment.NewLine);
                txt_peopledetails.AppendText(people.office + Environment.NewLine);
                txt_peopledetails.AppendText(people.website + Environment.NewLine);
                txt_peopledetails.AppendText(people.facebook + Environment.NewLine);
                txt_peopledetails.AppendText(people.twitter + Environment.NewLine);
                pb_peopledetails.Load(people.imagePath);
               
            }

            else
            {
                Staff staff = JToken.Parse(jsonPeople).ToObject<Staff>();
                txt_peopledetails.Text = "";
                txt_peopledetails.AppendText(staff.name + Environment.NewLine);
                txt_peopledetails.AppendText(staff.title + Environment.NewLine);
                txt_peopledetails.AppendText(staff.office + Environment.NewLine);
                txt_peopledetails.AppendText(staff.email + Environment.NewLine);
                txt_peopledetails.AppendText(staff.phone + Environment.NewLine);
                pb_peopledetails.Load(staff.imagePath);

            }
            

        }
    }
}
