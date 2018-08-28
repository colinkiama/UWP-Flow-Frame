using Flow_Frame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;

namespace Flow_Frame
{
    public sealed class FlowFrame : Frame
    {
        private Page CurrentPage => Content as Page;


        public new bool Navigate(Type sourcePageType)
        {
            AsyncMask(AnimationService.AnimatePageOut(CurrentPage));
            bool navigated = base.Navigate(sourcePageType);
            AsyncMask(AnimationService.AnimatePageIn(CurrentPage));
            return navigated;
        }

        public new void GoBack()
        {
            base.GoBack();
        }

        private bool CheckIfFirstForwardStackItemHasPageType(Type pageType)
        {
            bool frameHistoryHasPageType = false;
            var pageList = ForwardStack;
            if (pageList.Count > 1)
            {
                frameHistoryHasPageType = (pageList.First().SourcePageType == pageType);
            }

            return frameHistoryHasPageType;
        }

        public void AsyncMask(Task taskToRun)
        {
            Task.Run(async () => await taskToRun).GetAwaiter().GetResult();
        }
    }
}
