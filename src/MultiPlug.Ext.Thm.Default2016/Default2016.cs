using MultiPlug.Extension.Core;
using MultiPlug.Extension.Core.Http;
using MultiPlug.Theme.Default2016.Properties;

namespace MultiPlug.Theme.Default2016
{
    public class Default2016 : MultiPlugExtension
    {

        public override RazorTemplate[] RazorTemplates
        {
            get
            {
                return new RazorTemplate[]
                {
                    new RazorTemplate("Authentication", Resources.Authentication, false),
                    new RazorTemplate("Authorisation", Resources.Authorisation, false),
                    new RazorTemplate("HomeExtensions", Resources.HomeExtensions, false),
                    new RazorTemplate("Layout", Resources.Layout, false),
                    new RazorTemplate("NotFoundApp", Resources.NotFoundApp, false),
                    new RazorTemplate("NotFoundExtension", Resources.NotFoundExtension, false),
                    new RazorTemplate("NotFoundGlobal", Resources.NotFoundGlobal, false),
                    new RazorTemplate("HomeSettings", Resources.HomeSettings, false),
                    new RazorTemplate("SettingsAdd", Resources.SettingsAdd, false),
                    new RazorTemplate("SettingsUpdate", Resources.SettingsUpdate, false),
                    new RazorTemplate("FrameApp", Resources.FrameApp, false),
                    new RazorTemplate("FrameExtension", Resources.FrameExtension, false),
                    new RazorTemplate("HomeApps", Resources.HomeApps, false),
                    new RazorTemplate("HomeAnalytics", Resources.HomeAnalytics, false),
                    new RazorTemplate("InternalServerError", Resources.InternalServerError, false),
                    new RazorTemplate("SettingsHosting", Resources.SettingsHosting, false),
                    new RazorTemplate("SettingsHousekeeping", Resources.SettingsHousekeeping, false),
                    new RazorTemplate("SettingsHousekeepingStorage", Resources.SettingsHousekeepingStorage, false),
                    new RazorTemplate("SettingsExtensions", Resources.SettingsExtensions, false),
                    new RazorTemplate("SettingsPerformance", Resources.SettingsPerformance, false),
                    new RazorTemplate("SettingsRecipes", Resources.SettingsRecipes, false),
                    new RazorTemplate("SettingsSecurity", Resources.SettingsSecurity, false),
                    new RazorTemplate("SettingsEnvironment", Resources.SettingsEnvironment, false),
                    new RazorTemplate("SettingsApps", Resources.SettingsApps, false),
                    new RazorTemplate("SettingsPermissions", Resources.SettingsPermissions, false)
                };
            }
        }
    }
}
