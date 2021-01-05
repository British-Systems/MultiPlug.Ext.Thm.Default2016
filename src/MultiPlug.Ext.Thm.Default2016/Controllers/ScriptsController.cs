using System.Text;
using MultiPlug.Base.Attribute;
using MultiPlug.Base.Http;
using MultiPlug.Theme.Default2016.Properties;

namespace MultiPlug.Theme.Default2016.Controllers
{
    [Route("scripts/*")]
    public class ScriptsController : AssetsEndpoint
    {
        public Response Get(string id)
        {
            string result = "";

            //if (id == "jquery-1.6.4.min.js")
            //{
            //    result = Resources.jquery_1_6_4_min;
            //}
            //else if (id == "jquery.signalR-2.2.0.min.js")
            //{
            //    result = Resources.jquery_signalR_2_2_0_min;
            //}
            if (id == "modernizr-2.6.2.js")
            {
                result = Resources.modernizr_2_6_2_js;
            }
            //else if (id == "bootstrap.min.js")
            //{
            //    result = Resources.bootstrap_min;
            //}
            else if (id == "adminflare.min.js")
            {
                result = Resources.adminflare_min;
            }
            //else if (id == "jstree.min.js")
            //{
            //    result = Resources.jstree_min;
            //}
            else if (id == "select2.min.js")
            {
                result = Resources.select2_min;
            }
            else if (id == "selectize.min.js")
            {
                result = Resources.selectize_min;
            }
            else if (id == "multiplug.selectize.js")
            {
                result = Resources.multiplug_selectize;
            }
            else if (id == "deploy.js")
            {
                result = Resources.deploy_js;
            }


            if (result != "")
            {
                return new Response { MediaType = "text/javascript", RawBytes = Encoding.ASCII.GetBytes(result) };
            }
            else
            {
                return new Response { StatusCode = System.Net.HttpStatusCode.NotFound };
            }
        }
    }
}
