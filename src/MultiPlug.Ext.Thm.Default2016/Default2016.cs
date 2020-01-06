using MultiPlug.Extension.Core;
using MultiPlug.Extension.Core.Theme;

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
    }
}
