using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
namespace SchoolManagementSystem
{
    public partial class index : System.Web.UI.Page
    {
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable dt = new DataTable();
                //dt = objc.loaddt("SELECT Title, ShortDescription FROM WebSite_Post");
                //Slider1t.InnerText = dt.Rows[0]["Title"].ToString();
                //Slider1sd.InnerText = dt.Rows[0]["ShortDescription"].ToString();
            }
        }
    }
}