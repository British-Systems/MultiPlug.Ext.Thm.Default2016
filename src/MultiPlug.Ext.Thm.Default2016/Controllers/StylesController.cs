using System.Text;
using MultiPlug.Base.Attribute;
using MultiPlug.Base.Http;
using MultiPlug.Ext.Thm.Default2016.Properties;

namespace MultiPlug.Ext.Thm.Default2016.Controllers
{
    [Route("styles/*")]
    public class StylesController : AssetsEndpoint
    {
        public Response Get(string FileName)
        {
            string result = "";

            if (FileName.StartsWith("adminflare.min.") && FileName.EndsWith(".css"))
            {
                result = Resources.adminflare_min1;
            }
            else if (FileName == "bootstrap.min.css")
            {
                result = Resources.bootstrap_min_css;
            }
            else if (FileName == "font.awesome.min.css")
            {
                result = Resources.font_awesome_css;
            }
            else if (FileName == "pages.min.css")
            {
                result = Resources.pages_min;
            }
            //else if (FileName == "jstree.style.min.css")
            //{
            //    result = Resources.jstree_style_min;
            //}
            else if (FileName == "select2.min.css")
            {
                result = Resources.select2_min1;
            }
            else if (FileName == "selectize.default.css")
            {
                result = Resources.selectize_default;
            }
            else if (FileName == "fonts.css")
            {
                result = Resources.fonts;
            }
            else if (FileName == "multiplug.css")
            {
                result = Resources.multiplug_css;
            }

            if (result != "")
            {
                return new Response { MediaType = "text/css", RawBytes = Encoding.ASCII.GetBytes(result) };
            }
            else
            {
                return new Response { StatusCode = System.Net.HttpStatusCode.NotFound };
            }
        }
    }
}
