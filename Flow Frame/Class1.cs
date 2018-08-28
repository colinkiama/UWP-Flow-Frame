using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Flow_Frame
{
    public sealed class FlowFrame: Frame
    {
        public new bool Navigate(Type sourcePageType)
        {
            bool navigated = base.Navigate(sourcePageType);
            return navigated;
        }

        public new void GoBack()
        {
            base.GoBack();
        }
    }
}
