using System.Drawing;
using MultiPlug.Base.Attribute;
using MultiPlug.Base.Http;
using MultiPlug.Theme.Default2016.Properties;

namespace MultiPlug.Theme.Default2016.Controllers
{
    [Route("images/*")]
    public class ImagesController : AssetsEndpoint
    {
        public Response Get(string image)
        {
            System.Drawing.Bitmap result = null; ;

            string type = "image/png";

            //if (id == "brand.png")
            //{
            //    result = Resources.logo_png;
            //}
            if (image == "MultiPlug.png")
            {
                result = Resources.MultiPlug_Small;
            }
            else if (image == "MultiPlug-Login.png")
            {
                result = Resources.MultiPlug_Login;
            }
            else if (image == "MultiPlug-Icon.png")
            {
                result = Resources.MultiPlug_Icon;
            }
            //else if (image == "af-logo-signin.png")
            //{
            //    result = Resources.afaf_logo_signin;
            //}
            else if (image == "avatar.png")
            {
                result = Resources.avatar;
            }
            else if (image == "body-bg.png")
            {
                result = Resources.body_bg;
            }
            else if (image == "left-menu-bg.png")
            {
                result = Resources.left_menu_bg;
            }
            else if (image == "40px.png")
            {
                result = Resources._40px;
            }
            else if (image == "multiplug.png")
            {
                result = Resources.MultiPlug;
                type = "image/png";
            }
            else if (image == "evaluation-stamp.png")
            {
                result = Resources.evaluation_stamp;
                type = "image/png";
            }
            else if (image == "british-systems-fade.png")
            {
                result = Resources.British_Systems_Logo_Fade;
                type = "image/png";
            }

            if (result != null)
            {
                ImageConverter converter = new ImageConverter();
                return new Response { MediaType = type, RawBytes = (byte[])converter.ConvertTo(result, typeof(byte[])) };
            }
            else
            {
                return new Response { StatusCode = System.Net.HttpStatusCode.NotFound };
            }
        }
    }
}
