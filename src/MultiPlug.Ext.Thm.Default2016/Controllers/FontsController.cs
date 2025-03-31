using MultiPlug.Base.Attribute;
using MultiPlug.Base.Http;
using MultiPlug.Ext.Thm.Default2016.Properties;

namespace MultiPlug.Ext.Thm.Default2016.Controllers
{
    [Route("fonts/*")]
    public class FontsController : AssetsEndpoint
    {
        public Response Get(string FileName)
        {
            string mediatype = "";

            byte[] ResultByte = null;

            if (FileName == "FontAwesome.otf")
            {
                ResultByte = Resources.FontAwesome_otf;
                mediatype = "application/font-sfnt";
            }
            else if (FileName == "fontawesome-webfont.eot")
            {
                ResultByte = Resources.fontawesome_webfont_eot;
                mediatype = "application/font-sfnt";
            }
            else if (FileName == "fontawesome-webfont.svg")
            {
                //result = Resources.fontawesome_webfont_svg;
                ResultByte = Resources.fontawesome_webfont_svg;
                mediatype = "image/svg+xml";
            }
            else if (FileName == "fontawesome-webfont.ttf")
            {
                ResultByte = Resources.fontawesome_webfont_ttf;
                mediatype = "application/font-sfnt";
            }
            else if (FileName == "fontawesome-webfont.woff")
            {
                ResultByte = Resources.fontawesome_webfont_woff;
                mediatype = "application/font-woff";
            }
            else if (FileName == "multiplug.svg")
            {
                ResultByte = Resources.multiplug_svg;
                mediatype = "image/svg+xml";
            }
            else if (FileName == "multiplug.eot")
            {
                ResultByte = Resources.multiplug_eot;
                mediatype = "application/font-sfnt";
            }
            else if (FileName == "multiplug.ttf")
            {
                ResultByte = Resources.multiplug_ttf;
                mediatype = "application/font-sfnt";
            }
            else if (FileName == "multiplug.woff")
            {
                ResultByte = Resources.multiplug_ttf;
                mediatype = "application/font-woff";
            }
            else
            {
                var FileNameSplit = FileName.Split('.');

                if(FileNameSplit.Length == 2 && FileNameSplit[1] == "woff2")
                {
                    var FileNameExtentionRemoved = FileName.Split('.')[0];
                    mediatype = "application/font-woff2";
                    ResultByte = (byte[]) Resources.ResourceManager.GetObject(FileNameExtentionRemoved, Resources.Culture);
                }
            }

            if (mediatype != "")
            {
                return new Response { MediaType = mediatype, RawBytes = ResultByte };
            }
            else
            {
                return new Response { StatusCode = System.Net.HttpStatusCode.NotFound };
            }
        }
    }
}
