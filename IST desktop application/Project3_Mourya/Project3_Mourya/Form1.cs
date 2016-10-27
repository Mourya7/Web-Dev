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
    public partial class Form1 : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        public string selectedPeopleTab = "faculty";
        public int loadResearch = 0;
        public int loadNews = 0;
        //people faculty and staff
        string jsonPeople;
        People people;

        //research byfaculty and interest area
        string jsonResearch;
        Research research;

        string jsonResource;
        Resources resource;

        string jsonEmp;
        Employment employment;

        string jsonDegrees;
        Degrees degrees;

        public Form1()
        {
            InitializeComponent();

            jsonPeople = rj.getJSON("/people/");
            people = JToken.Parse(jsonPeople).ToObject<People>();

            jsonResearch = rj.getJSON("/research/");
            research = JToken.Parse(jsonResearch).ToObject<Research>();

            jsonResource = rj.getJSON("/resources/");
            resource = JToken.Parse(jsonResource).ToObject<Resources>();

            jsonEmp = rj.getJSON("/employment/");
            employment = JToken.Parse(jsonEmp).ToObject<Employment>();

            jsonDegrees = rj.getJSON("/degrees/");
            degrees = JToken.Parse(jsonDegrees).ToObject<Degrees>();
        }

        //about section on load of form
        private void Form1_Load(object sender, EventArgs e)
        {
            string jsonAbout = rj.getJSON("/about/");
            About about = JToken.Parse(jsonAbout).ToObject<About>();
            txt_about.Text = "";
            txt_about.AppendText(about.title + Environment.NewLine);
            txt_about.AppendText(Environment.NewLine + about.description + Environment.NewLine);
            txt_about.AppendText(Environment.NewLine + about.quote);
            txt_about.AppendText(Environment.NewLine + about.quoteAuthor);
        }

        //Degrees
        //On click of Undergraduate button 
        private void btn_undergraduate_Click(object sender, EventArgs e)
        {
            gb_advCert.Text = "";
            Label l1 = (Label)gb_advCert.Controls[0];
            Label l2 = (Label)gb_advCert.Controls[1];
            txt_degree_description.Text = "";
            gb_advCert.Visible = false;

            l1.Text = "";
            l2.Text = "";
            //declare and initialize varibles to hold data
            int i = 0;
            int j = 0;
            string[] underGradDegree = new string[3];
            string[] degreeDesc = new string[3];
            string[] conc = new string[7];


            //Get the json data for degrees
            string jsonDegrees = rj.getJSON("/degrees/");
            Degrees degrees = JToken.Parse(jsonDegrees).ToObject<Degrees>();

            foreach (Undergraduate ug in degrees.undergraduate)
            {
                underGradDegree[i] = ug.title;
                degreeDesc[i] = ug.description;
                i++;
                j = 0;
                foreach(string concentration in ug.concentrations)
                {
                    conc[j] = concentration;
                    j++;
                }
            }

            i = gb_degrees.Controls.Count-1;
            foreach (Button b in gb_degrees.Controls)
            {
                    b.Text = underGradDegree[i];
                    b.Tag = degreeDesc[i];
                    b.Enabled = true;
                i--;
            }
        }

        //Degrees
        //On click of graduate button
        private void btn_graduate_Click(object sender, EventArgs e)
        {
            txt_degree_description.Text = "";
            gb_advCert.Visible = true;
            //declare and initialize varibles to hold data
            int i = 0, j = 0 ;
            string[] gradDegree = new string[3];
            string[] degreeDesc = new string[3];
            string[] gradAdCert = new string[2];
            string[] conc = new string[7];

            foreach (Graduate gd in degrees.graduate)
            {
                if(gd.title != null)
                {
                    gradDegree[i] = gd.title;
                    degreeDesc[i] = gd.description;
                    i++;
                    j = 0;
                    foreach (string concentration in gd.concentrations)
                    {
                        conc[j] = concentration;
                        j++;
                    }
                }

                else
                {
                    gb_advCert.Text = gd.degreeName;
                    j = 0;
                    foreach (string adv in gd.availableCertificates)
                    {
                        gradAdCert[j] = adv;
                        j++;
                    }
                }
                
            }

            i = gb_degrees.Controls.Count - 1;
            foreach (Button b in gb_degrees.Controls)
            {
                b.Text = gradDegree[i];
                b.Tag = degreeDesc[i];
                b.Enabled = true;
                i--;
            }

            //i = gb_advCert.Controls.Count - 1;
            Label l1 = (Label)gb_advCert.Controls[0];
            Label l2 = (Label)gb_advCert.Controls[1];

            l1.Text = gradAdCert[0];
            l2.Text = gradAdCert[1];
        }

        //On click of each button 
        private void btn_spec1_Click(object sender, EventArgs e)
        {
             txt_degree_description.Text = " ";
             txt_degree_description.AppendText(btn_spec1.Text + Environment.NewLine);
             txt_degree_description.AppendText((string)btn_spec1.Tag);
        }

        private void btn_spec2_Click(object sender, EventArgs e)
        {
            txt_degree_description.Text = " ";
            txt_degree_description.AppendText(btn_spec2.Text + Environment.NewLine);
            txt_degree_description.AppendText((string)btn_spec2.Tag);
        }

        private void btn_spec3_Click(object sender, EventArgs e)
        {
            txt_degree_description.Text = " ";
            txt_degree_description.AppendText(btn_spec3.Text + Environment.NewLine);
            txt_degree_description.AppendText((string)btn_spec3.Tag);
        }
        // ------------------------------- End of grad section ---------------------------------------------

        //click of each minor button
        private void btn_dbddi_Click(object sender, EventArgs e)
        {
            Minor_details md = new Minor_details((string)btn_dbddi.Tag);
            md.ShowDialog();
        }

        private void btn_gis_Click(object sender, EventArgs e)
        {
            Minor_details md = new Minor_details((string)btn_gis.Tag);
            md.ShowDialog();
        }

        private void btn_health_Click(object sender, EventArgs e)
        {
            Minor_details md = new Minor_details((string)btn_health.Tag);
            md.ShowDialog();
        }

        private void btn_mobiledes_Click(object sender, EventArgs e)
        {
            Minor_details md = new Minor_details((string)btn_mobiledes.Tag);
            md.ShowDialog();
        }

        private void btn_mobiledev_Click(object sender, EventArgs e)
        {
            Minor_details md = new Minor_details((string)btn_mobiledev.Tag);
            md.ShowDialog();
        }

        private void btn_netsys_Click(object sender, EventArgs e)
        {
            Minor_details md = new Minor_details((string)btn_netsys.Tag);
            md.ShowDialog();
        }

        private void btn_webdes_Click(object sender, EventArgs e)
        {
            Minor_details md = new Minor_details((string)btn_webdes.Tag);
            md.ShowDialog();
        }

        private void btn_webdev_Click(object sender, EventArgs e)
        {
            Minor_details md = new Minor_details((string)btn_webdev.Tag);
            md.ShowDialog();
        }

        //------------------------------------------------------ End of Minor scetion

        // People Tab
        // Load Faculty names
        private void tb_people_Enter(object sender, EventArgs e)
        {
            

            string[] facultyName = new string[35];
            string[] facultyUname = new string[35];
            
            int i = 0;

            foreach (Faculty fac in people.faculty)
            {
                facultyName[i] = fac.name;
                facultyUname[i] = fac.username;
                i++;
            }

            i = tb_faculty.Controls.Count - 1;
            foreach (Button b in tb_faculty.Controls)
            {
                    b.Text = facultyName[i];
                    b.Tag = facultyUname[i];
                    i--;
            }
        }

        // Load staff names
        private void tb_staff_Enter(object sender, EventArgs e)
        {
            selectedPeopleTab = "staff";
            
            string[] staffName = new string[20];
            string[] staffUname = new string[20];
            int i = 0;

            foreach (Staff thisStaff in people.staff)
            {
                staffName[i] = thisStaff.name;
                staffUname[i] = thisStaff.username;
                i++;
            }

            i = tb_staff.Controls.Count - 1;
            foreach (Button b in tb_staff.Controls)
            {
                b.Text = staffName[i];
                b.Tag = staffUname[i];
                i--;
            }
        }

        // for url reference
        private void tb_faculty_Enter(object sender, EventArgs e)
        {
            selectedPeopleTab = "faculty";
        }


        // on click of each button
        private void button1_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button1.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button2.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button3.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button4.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button5.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button6.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button7.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button14.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button13.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button12.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button11.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button10.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button9.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button8.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button21.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button20.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button19.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button18.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button17.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button16.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button15.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button28.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button27.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button26.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button25.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button24.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button23.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button22.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button35.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button34.Tag, selectedPeopleTab);
            pds.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button33.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button32.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button31.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        //on click of each staff
        private void button36_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button36.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button37.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button38.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button39.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button40.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button45.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button44.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button43.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button42.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button41.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button50.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button49.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            People_details pds = new People_details((string)button48.Tag, selectedPeopleTab);
            pds.ShowDialog();
        }


        // -------------End of People and staff section ------------ (uff!! Finally)--------------------


        //--- start of research by faculty

        private void tb_rbyfac_Enter(object sender, EventArgs e)
        {
            selectedPeopleTab = "faculty";
        }
        private void tb_research_Enter(object sender, EventArgs e)
        {
            selectedPeopleTab = "faculty";
            // return if page is already loaded 
            if (loadResearch == 1)
                return;

            string[] jsonFaculty = new string[21];
            Faculty[] faculty = new Faculty[21];
            string[] facultyUname = new string[21];
            string[] facultyName = new string[21];
            

            int i = 0;

            foreach (ByFaculty fac in research.byFaculty)
            {
                facultyName[i] = fac.facultyName;
                facultyUname[i] = fac.username;
                i++;
            }

            i = 0;

            foreach (Faculty fac in people.faculty)
            {
                if (i < 21)
                {

                    jsonFaculty[i] = rj.getJSON("/people/faculty/username=" + facultyUname[i]);
                    faculty[i] = JToken.Parse(jsonFaculty[i]).ToObject<Faculty>();
                    i = i + 1;
                }
                else
                {
                    break;
                }
            }

            i = tb_rbyfac.Controls.Count/2;
            foreach (Control c in tb_rbyfac.Controls)
            {
                if (c is PictureBox)
                {
                    PictureBox p = (PictureBox)c;
                    if (i > 0)
                    {
                        p.Load(faculty[i].imagePath);
                        p.Tag = faculty[i].username;
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            i = tb_rbyfac.Controls.Count / 2;
            foreach (Control c in tb_rbyfac.Controls)
            {
                if (c is Label)
                {
                    Label l = (Label)c;
                    if (i > 0)
                    {
                        l.Text = faculty[i].name;
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            loadResearch = 1;
        }

        // on click of picturebox of research by fac

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox2.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox14.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox18.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox1.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox3.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox4.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox5.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox6.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox12.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox11.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox10.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox9.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox8.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox7.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox17.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox16.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox15.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox13.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox19.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details((string)pictureBox20.Tag, selectedPeopleTab);
            rds.ShowDialog();
        }

        //-- End of by faculty 
        // -- By interest area section begins


        private void tb_aoi_Enter(object sender, EventArgs e)
        {
            selectedPeopleTab = "area";
            string[] areaName = new string[12];
            string[]  areaCitation = new string[12];

            int i = 0;
            foreach (ByInterestArea thisArea in research.byInterestArea)
            {
                areaName[i] = thisArea.areaName;
                i++;
            }



            i = tb_aoi.Controls.Count-1;
            foreach (Button b in tb_aoi.Controls)
            {
                b.Text = areaName[i];
                i--;
            }
        }

        //n click of each button of res by interest area
        private void btn_analytics_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_analytics.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_database_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_database.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_edu_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_edu.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_geo_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_geo.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_hci_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_hci.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_heathinfo_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_heathinfo.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_mobile_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_mobile.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_network_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_network.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_prog_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_prog.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_sysadmin_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_sysadmin.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_ubiq_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_ubiq.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        private void btn_web_Click(object sender, EventArgs e)
        {
            Research_details rds = new Research_details(btn_web.Text, selectedPeopleTab);
            rds.ShowDialog();
        }

        // end of re by area sec
        //------------------------------------- end of research section --------------

        // -- employment section begins-------------------------
        private void tb_employment_Enter(object sender, EventArgs e)
        {
           
           string jsonEmployment = rj.getJSON("/employment/");
           Employment emp = JToken.Parse(jsonEmployment).ToObject<Employment>();
            
           txt_emp.Text = "";
           lbl_empTitle.Text = emp.introduction.title;

           txt_emp.AppendText(emp.introduction.content[0].title+Environment.NewLine);
           txt_emp.AppendText(Environment.NewLine+emp.introduction.content[0].description);

           txt_coopedu.Text = "";
           txt_coopedu.AppendText(emp.introduction.content[1].title + Environment.NewLine);
           txt_coopedu.AppendText(Environment.NewLine+emp.introduction.content[1].description);

           int i = gb_degreeStats.Controls.Count-1;
           gb_degreeStats.Text = emp.degreeStatistics.title;
           foreach(RichTextBox rtb in gb_degreeStats.Controls)
           {
                rtb.Text = "";
                rtb.AppendText(emp.degreeStatistics.statistics[i].value+Environment.NewLine);
                rtb.AppendText(emp.degreeStatistics.statistics[i].description);
                i--;
           }

           txt_employers.Text = "";
           txt_employers.AppendText(emp.employers.title + Environment.NewLine + Environment.NewLine);
           foreach(string s in emp.employers.employerNames)
            {
                txt_employers.AppendText(s + Environment.NewLine);
            }

            txt_careers.Text = "";
            txt_careers.AppendText(emp.careers.title + Environment.NewLine + Environment.NewLine);
            foreach (string s in emp.careers.careerNames)
            {
                txt_careers.AppendText(s + Environment.NewLine);
            }

        }

        //---------------------------End of Employment section
        //-- student resource

        private void tb_resources_Enter(object sender, EventArgs e)
        {
            lbl_resTitle.Text = resource.title;
            lbl_resSub.Text = resource.subTitle;
        }

        //study abroad

        private void btn_studyabroad_Click(object sender, EventArgs e)
        {
            Resources_deatails rds = new Resources_deatails((string)btn_studyabroad.Tag);
            rds.ShowDialog();
        }

        //service
        private void btn_studserv_Click(object sender, EventArgs e)
        {
            Resources_deatails rds = new Resources_deatails((string)btn_studserv.Tag);
            rds.ShowDialog();
        }

        //tutors
        private void btn_tutor_Click(object sender, EventArgs e)
        {
            Resources_deatails rds = new Resources_deatails((string)btn_tutor.Tag);
            rds.ShowDialog();
        }

        //student ambassadors
        private void btn_studamb_Click(object sender, EventArgs e)
        {
            Resources_deatails rds = new Resources_deatails((string)btn_studamb.Tag);
            rds.ShowDialog();
        }

        //forms
        private void btn_forms_Click(object sender, EventArgs e)
        {
            Resources_deatails rds = new Resources_deatails((string)btn_forms.Tag);
            rds.ShowDialog();
        }

        //coop
        private void btn_coop_Click(object sender, EventArgs e)
        {
            Resources_deatails rds = new Resources_deatails((string)btn_coop.Tag);
            rds.ShowDialog();
        }
        //--------------------End of student resources

        //-News-
        private void tb_news_Enter(object sender, EventArgs e)
        {
            if (loadNews == 1)
                return;

            string jsonNews = rj.getJSON("/news/");
            News news = JToken.Parse(jsonNews).ToObject<News>();

            rtb_news.Text = "";
            foreach (Year period in news.year)
            {
                rtb_news.AppendText(Environment.NewLine + period.date + Environment.NewLine);
                rtb_news.AppendText(period.title + Environment.NewLine);
                rtb_news.AppendText(period.description + Environment.NewLine);
            }

            foreach (Quarter period in news.quarter)
            {
                rtb_news.AppendText(Environment.NewLine + period.date + Environment.NewLine);
                rtb_news.AppendText(period.title + Environment.NewLine);
                rtb_news.AppendText(period.description + Environment.NewLine);
            }

            foreach (Older period in news.older)
            {
                rtb_news.AppendText(Environment.NewLine + period.date + Environment.NewLine);
                rtb_news.AppendText(period.title + Environment.NewLine);
                rtb_news.AppendText(period.description + Environment.NewLine);
            }
            loadNews = 1;
        }
        //-------------------------End of news----------------
        //-footer-
        private void tb_socialp_Enter(object sender, EventArgs e)
        {
            string jsonFooter = rj.getJSON("/footer/");
            Footer footer = JToken.Parse(jsonFooter).ToObject<Footer>();

            rtb_socialpres.Text = "";
            rtb_socialpres.AppendText(footer.social.title + Environment.NewLine);
            rtb_socialpres.AppendText(footer.social.tweet + Environment.NewLine);
            rtb_socialpres.AppendText(footer.social.by);
            rtb_socialpres.AppendText(footer.social.twitter + Environment.NewLine);
            rtb_socialpres.AppendText(footer.social.facebook + Environment.NewLine);

            foreach(QuickLink quickLinks in footer.quickLinks)
            {
                rtb_socialpres.AppendText(Environment.NewLine + quickLinks.title + Environment.NewLine);
                rtb_socialpres.AppendText(quickLinks.href + Environment.NewLine);
            }

            rtb_socialpres.AppendText(Environment.NewLine+footer.copyright.title+ Environment.NewLine);
            rtb_socialpres.AppendText(Environment.NewLine+footer.news);

        }

        //---------------------------------End of footer

        private void btn_coopTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < employment.coopTable.coopInformation.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = employment.coopTable.coopInformation[i].employer;
                dataGridView1.Rows[i].Cells[1].Value = employment.coopTable.coopInformation[i].degree;
                dataGridView1.Rows[i].Cells[2].Value = employment.coopTable.coopInformation[i].city;
                dataGridView1.Rows[i].Cells[3].Value = employment.coopTable.coopInformation[i].term;
             }
            btn_coopTable.Enabled = false;
        }

        private void btn_empTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < employment.employmentTable.professionalEmploymentInformation.Count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = employment.employmentTable.professionalEmploymentInformation[i].degree;
                dataGridView2.Rows[i].Cells[1].Value = employment.employmentTable.professionalEmploymentInformation[i].employer;
                dataGridView2.Rows[i].Cells[2].Value = employment.employmentTable.professionalEmploymentInformation[i].city;
                dataGridView2.Rows[i].Cells[3].Value = employment.employmentTable.professionalEmploymentInformation[i].title;
                dataGridView2.Rows[i].Cells[4].Value = employment.employmentTable.professionalEmploymentInformation[i].startDate;
            }
            btn_empTable.Enabled = false;
        }
    }
}
