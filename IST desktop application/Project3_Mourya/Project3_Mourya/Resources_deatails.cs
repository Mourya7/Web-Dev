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
    public partial class Resources_deatails : Form
    {
        REST rj = new REST("http://ist.rit.edu/api");
        public Resources_deatails(string reference)
        {
            InitializeComponent();
            string jsonResource = rj.getJSON("/resources/");
            Resources resource = JToken.Parse(jsonResource).ToObject<Resources>();

            if (reference == "studyAbroad")
            {
                txt_resourcedetails.Text = "";
                txt_resourcedetails.AppendText(resource.studyAbroad.title + Environment.NewLine);
                txt_resourcedetails.AppendText(Environment.NewLine + resource.studyAbroad.description + Environment.NewLine);

                foreach (Place place in resource.studyAbroad.places)
                {
                    txt_resourcedetails.AppendText(Environment.NewLine + place.nameOfPlace + Environment.NewLine);
                    txt_resourcedetails.AppendText(Environment.NewLine + place.description + Environment.NewLine);
                }
            }

            if (reference == "studentServices")
            {
                txt_resourcedetails.Text = "";
                //title
                txt_resourcedetails.AppendText(resource.studentServices.title + Environment.NewLine);

                //academicadvisor
                txt_resourcedetails.AppendText(Environment.NewLine+resource.studentServices.academicAdvisors.title + Environment.NewLine);
                txt_resourcedetails.AppendText(resource.studentServices.academicAdvisors.description + Environment.NewLine);

                //faq
                txt_resourcedetails.AppendText(Environment.NewLine + resource.studentServices.academicAdvisors.faq.title + Environment.NewLine);
                txt_resourcedetails.AppendText(resource.studentServices.academicAdvisors.faq.contentHref + Environment.NewLine);

                //professional advisor
                txt_resourcedetails.AppendText(Environment.NewLine + resource.studentServices.professonalAdvisors.title + Environment.NewLine);
                foreach(AdvisorInformation advInfo in resource.studentServices.professonalAdvisors.advisorInformation)
                {
                    txt_resourcedetails.AppendText(Environment.NewLine+advInfo.name+ Environment.NewLine);
                    txt_resourcedetails.AppendText(advInfo.department + Environment.NewLine);
                    txt_resourcedetails.AppendText(advInfo.email + Environment.NewLine);
                }

                //facultyadvisor
                txt_resourcedetails.AppendText(Environment.NewLine+resource.studentServices.facultyAdvisors.title+Environment.NewLine);
                txt_resourcedetails.AppendText(Environment.NewLine+resource.studentServices.facultyAdvisors.description + Environment.NewLine);

                //istminoradvising
                txt_resourcedetails.AppendText(resource.studentServices.istMinorAdvising.title + Environment.NewLine);
                foreach(MinorAdvisorInformation minAdvInfo in resource.studentServices.istMinorAdvising.minorAdvisorInformation)
                {
                    txt_resourcedetails.AppendText(Environment.NewLine + minAdvInfo.title + Environment.NewLine);
                    txt_resourcedetails.AppendText(minAdvInfo.advisor + Environment.NewLine);
                    txt_resourcedetails.AppendText(minAdvInfo.email + Environment.NewLine);
                }
            }

            if(reference == "tutorsAndLabInformation")
            {
                txt_resourcedetails.Text = "";

                txt_resourcedetails.AppendText(resource.tutorsAndLabInformation.title + Environment.NewLine);
                txt_resourcedetails.AppendText(resource.tutorsAndLabInformation.description + Environment.NewLine);
                txt_resourcedetails.AppendText(resource.tutorsAndLabInformation.tutoringLabHoursLink + Environment.NewLine);

            }

            if(reference == "studentAmbassadors")
            {
                txt_resourcedetails.Text = "";

                txt_resourcedetails.AppendText(resource.studentAmbassadors.title + Environment.NewLine);
                foreach(SubSectionContent subSection in resource.studentAmbassadors.subSectionContent)
                {
                    txt_resourcedetails.AppendText(Environment.NewLine+ subSection.title+ Environment.NewLine);
                    txt_resourcedetails.AppendText(subSection.description + Environment.NewLine);

                }
                txt_resourcedetails.AppendText(resource.studentAmbassadors.applicationFormLink + Environment.NewLine);
                txt_resourcedetails.AppendText(resource.studentAmbassadors.note + Environment.NewLine);
            }

            if(reference=="forms")
            {
                txt_resourcedetails.Text = "";

                foreach(GraduateForm gdf in resource.forms.graduateForms)
                {
                    txt_resourcedetails.AppendText(Environment.NewLine + gdf.formName + Environment.NewLine);
                    txt_resourcedetails.AppendText(gdf.href + Environment.NewLine);
                }

                foreach(UndergraduateForm ugf in resource.forms.undergraduateForms)
                {
                    txt_resourcedetails.AppendText(Environment.NewLine + ugf.formName + Environment.NewLine);
                    txt_resourcedetails.AppendText(ugf.href + Environment.NewLine);
                }
            }

            if (reference == "coopEnrollment")
            {
                txt_resourcedetails.Text = "";
                txt_resourcedetails.AppendText(resource.coopEnrollment.title + Environment.NewLine);

                foreach (EnrollmentInformationContent eic in resource.coopEnrollment.enrollmentInformationContent)
                {
                    txt_resourcedetails.AppendText(Environment.NewLine + eic.title + Environment.NewLine);
                    txt_resourcedetails.AppendText(eic.description + Environment.NewLine);
                }

                txt_resourcedetails.AppendText(resource.coopEnrollment.RITJobZoneGuidelink);
            }

        }
    }
}
