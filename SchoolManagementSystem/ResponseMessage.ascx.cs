using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealProjectB1
{
    public partial class ResponseMessage : System.Web.UI.UserControl
    {
        public string SuccessMessage
        {
            set
            {
                pSuccess.Visible = true;
                pFailure.Visible = false;
                lSuccess.Text = value;
            }
            get
            {
                return lSuccess.Text;
            }
        }
        public string FailureMessage
        {
            set
            {
                pFailure.Visible = true;
                pSuccess.Visible = false;
                lFailure.Text = value;
            }
            get
            {
                return lFailure.Text;
            }
        }
        public void SetResponseMessageVisibleFalse()
        {
            pSuccess.Visible = false;
            pFailure.Visible = false;
        }
        public void Initialize()
        {
            pSuccess.Visible = false;
            pFailure.Visible = false;
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
    }
}