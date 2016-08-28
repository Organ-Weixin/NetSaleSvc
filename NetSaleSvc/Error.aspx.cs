using System;

namespace NetSaleSvc
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("请按要求传递正确路径及参数，非常感谢！");
        }
    }
}