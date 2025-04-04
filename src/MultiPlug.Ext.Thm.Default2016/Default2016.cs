﻿using MultiPlug.Extension.Core;
using MultiPlug.Extension.Core.Http;
using MultiPlug.Ext.Thm.Default2016.Properties;

namespace MultiPlug.Ext.Thm.Default2016
{
    public class Default2016 : MultiPlugExtension
    {
        public override RazorTemplate[] RazorTemplates
        {
            get
            {
                return new RazorTemplate[]
                {
                    new RazorTemplate("HomeExtensions", Resources.HomeExtensions, false),
                    new RazorTemplate("Layout", Resources.Layout, false),
                    new RazorTemplate("HomeSettings", Resources.HomeSettings, false),
                    new RazorTemplate("SettingsAdd", Resources.SettingsAdd, false),
                    new RazorTemplate("SettingsUpdate", Resources.SettingsUpdate, false),
                    new RazorTemplate("FrameApp", Resources.FrameApp, false),
                    new RazorTemplate("FrameExtension", Resources.FrameExtension, false),
                    new RazorTemplate("HomeApps", Resources.HomeApps, false),
                    new RazorTemplate("HomeAnalytics", Resources.HomeAnalytics, false),
                    new RazorTemplate("SettingsHosting", Resources.SettingsHosting, false),
                    new RazorTemplate("SettingsHousekeeping", Resources.SettingsHousekeeping, false),
                    new RazorTemplate("SettingsHousekeepingStorage", Resources.SettingsHousekeepingStorage, false),
                    new RazorTemplate("SettingsExtensions", Resources.SettingsExtensions, false),
                    new RazorTemplate("SettingsPerformance", Resources.SettingsPerformance, false),
                    new RazorTemplate("SettingsRecipes", Resources.SettingsRecipes, false),
                    new RazorTemplate("SettingsSecurity", Resources.SettingsSecurity, false),
                    new RazorTemplate("SettingsEnvironment", Resources.SettingsEnvironment, false),
                    new RazorTemplate("SettingsApps", Resources.SettingsApps, false),
                    new RazorTemplate("SettingsPermissions", Resources.SettingsPermissions, false),
                    new RazorTemplate("SettingsHome", Resources.SettingsHome, true)
                };
            }
        }
    }
}
