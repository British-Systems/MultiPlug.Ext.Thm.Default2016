using MultiPlug.Extension.Core;
using MultiPlug.Extension.Core.Http;
using MultiPlug.Extension.Core.Theme;
using MultiPlug.Theme.Default2016.Properties;

namespace MultiPlug.Theme.Default2016
{
    public class Default2016 : MultiPlugExtension, ITheme
    {

        private Core m_Core = new Core();

        public Pages Pages
        {
            get
            {
                return m_Core;
            }
        }

        public override RazorTemplate[] RazorTemplates
        {
            get
            {
                return new RazorTemplate[]
                {
                    new RazorTemplate("Authorisation", Resources.Authorisation),
                    new RazorTemplate("HomeExtensions", Resources.HomeExtensions),
                    new RazorTemplate("Layout", Resources.Layout),
                    new RazorTemplate("NotFoundApp", Resources.NotFoundApp),
                    new RazorTemplate("NotFoundExtension", Resources.NotFoundExtension),
                    new RazorTemplate("NotFoundGlobal", Resources.NotFoundGlobal),
                    new RazorTemplate("HomeSettings", Resources.HomeSettings),
                    new RazorTemplate("SettingsAdd", Resources.SettingsAdd),
                    new RazorTemplate("SettingsUpdate", Resources.SettingsUpdate),
                    new RazorTemplate("FrameApp", Resources.FrameApp),
                    new RazorTemplate("FrameExtension", Resources.FrameExtension),
                    new RazorTemplate("HomeApps", Resources.HomeApps),
                    new RazorTemplate("InternalServerError", Resources.InternalServerError),
                    new RazorTemplate("SettingsHosting", Resources.SettingsHosting),
                    new RazorTemplate("SettingsHousekeeping", Resources.SettingsHousekeeping),
                    new RazorTemplate("SettingsExtensions", Resources.SettingsExtensions),
                    new RazorTemplate("SettingsPerformance", Resources.SettingsPerformance),
                    new RazorTemplate("SettingsRecipes", Resources.SettingsRecipes),
                    new RazorTemplate("SettingsSecurity", Resources.SettingsSecurity),
                    new RazorTemplate("SettingsSystem", Resources.SettingsSystem),
                    new RazorTemplate("SettingsApps", Resources.SettingsApps)
                };
            }
        }
    }
}
