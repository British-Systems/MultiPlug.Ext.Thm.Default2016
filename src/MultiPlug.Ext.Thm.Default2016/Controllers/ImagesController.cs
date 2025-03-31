using System.Drawing;
using MultiPlug.Base.Attribute;
using MultiPlug.Base.Http;
using MultiPlug.Ext.Thm.Default2016.Properties;

namespace MultiPlug.Ext.Thm.Default2016.Controllers
{
    [Route("images/*")]
    public class ImagesController : AssetsEndpoint
    {
        public Response Get(string image)
        {
            Bitmap result = null; ;

            string type = "image/png";

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
            else if (image == "avatar.png")
            {
                result = Resources.avatar;
            }
            else if (image.StartsWith("body-bg.") && image.EndsWith(".png"))
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
