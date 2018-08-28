using Flow_Frame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Flow_Frame
{
    public sealed class FlowFrame : Frame
    {
        private Page CurrentPage => Content as Page;


        public new IAsyncOperation<bool> Navigate(Type sourcePageType)
        {
            return Task.Run(async () =>
            {
                bool navigated = false;
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, async () =>
                {
                    await AnimationService.AnimatePageOut(CurrentPage);
                    navigated = base.Navigate(sourcePageType, null, new SuppressNavigationTransitionInfo());
                    await AnimationService.AnimatePageIn(CurrentPage);
                });
                return navigated;
            }).AsAsyncOperation();
        }

        public new IAsyncOperation<bool> Navigate(Type sourcePageType, object parameter)
        {
            return Task.Run(async () =>
            {
                bool navigated = false;
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, async () =>
                {
                    await AnimationService.AnimatePageOut(CurrentPage);
                    navigated = base.Navigate(sourcePageType,parameter, new SuppressNavigationTransitionInfo());
                    await AnimationService.AnimatePageIn(CurrentPage);
                });
                return navigated;
            }).AsAsyncOperation();
        }

        public new IAsyncAction GoBack()
        {
            return Task.Run(async () =>
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, async () =>
                {
                    await AnimationService.AnimatePageOutReverse(CurrentPage);
                    base.GoBack(new SuppressNavigationTransitionInfo());
                    await AnimationService.AnimatePageInReverse(CurrentPage);
                });
            }).AsAsyncAction();
            
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


    }
}
