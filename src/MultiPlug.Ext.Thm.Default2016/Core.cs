using System;
using System.Collections.Generic;
using MultiPlug.Base.Http;
using MultiPlug.Theme.Default2016.Properties;
using MultiPlug.Theme.Default2016.Controllers;
using MultiPlug.Base.Exchange;
using MultiPlug.Extension.Core.Theme;

namespace MultiPlug.Theme.Default2016
{
    public class Core : Pages
    {

        private Type[] m_Controllers = new Type[]
        {
            typeof(ImagesController),
            typeof(FontsController),
            typeof(ScriptsController),
            typeof(StylesController)
        };

        public override StringContainer Authorisation
        {
            get
            {
                return new StringContainer { Value = Resources.Authorisation };
            }
        }

        public override StringContainer HomeExtensions
        {
            get
            {
                return new StringContainer { Value = Resources.HomeExtensions };
            }
        }

        public override StringContainer Layout
        {
            get
            {
                return new StringContainer { Value = Resources.Layout };
            }
        }

        public override StringContainer NotFoundApp
        {
            get
            {
                return new StringContainer { Value = Resources.NotFoundApp };
            }
        }

        public override StringContainer NotFoundExtension
        {
            get
            {
                return new StringContainer { Value = Resources.NotFoundExtension };
            }
        }

        public override StringContainer NotFoundGlobal
        {
            get
            {
                return new StringContainer { Value = Resources.NotFoundGlobal };
            }
        }

        public override StringContainer HomeSettings
        {
            get
            {
                return new StringContainer { Value = Resources.HomeSettings };
            }
        }

        public override StringContainer SettingsAdd
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsAdd };
            }
        }

        public override StringContainer SettingsUpdate
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsUpdate };
            }
        }

        public override StringContainer FrameApp
        {
            get
            {
                return new StringContainer { Value = Resources.FrameApp };
            }
        }

        public override StringContainer FrameExtension
        {
            get
            {
                return new StringContainer { Value = Resources.FrameExtension };
            }
        }

        public override StringContainer HomeApps
        {
            get
            {
                return new StringContainer { Value = Resources.HomeApps };
            }
        }

        public override StringContainer InternalServerError
        {
            get
            {
                return new StringContainer { Value = Resources.InternalServerError };
            }
        }

        public override IEnumerable<Type> ControllersMultiThread
        {
            get
            {
                return m_Controllers;
            }
        }

        public override StringContainer SettingsHosting
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsHosting };
            }
        }

        public override StringContainer SettingsHousekeeping
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsHousekeeping };
            }
        }

        public override StringContainer SettingsExtensions
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsExtensions };
            }
        }

        public override StringContainer SettingsPerformance
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsPerformance };
            }
        }

        public override StringContainer SettingsRecipes
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsRecipes };
            }
        }

        public override StringContainer SettingsSecurity
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsSecurity };
            }
        }

        public override StringContainer SettingsSystem
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsSystem };
            }
        }

        public override StringContainer SettingsApps
        {
            get
            {
                return new StringContainer { Value = Resources.SettingsApps };
            }
        }
    }
}
