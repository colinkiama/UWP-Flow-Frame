using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;

namespace Flow_Frame.Services
{
    internal class AnimationService
    {
        private static Compositor _compositor;
        const string systemBackgroundColourKey = "SystemControlBackgroundAltHighBrush";

        internal static async Task AnimatePageInReverse(Frame frame)
        {
            if (frame.Content is FrameworkElement page)
            {
                if (_compositor == null)
                    _compositor = ElementCompositionPreview.GetElementVisual(page).Compositor;

                var visual = ElementCompositionPreview.GetElementVisual(page);

                visual.Offset = new Vector3(-140, 0, 0);
                visual.Opacity = 0f;
                visual.Scale = new Vector3(1, 1, 0);

                KeyFrameAnimation offsetInAnimation = _compositor.CreateScalarKeyFrameAnimation();
                offsetInAnimation.InsertExpressionKeyFrame(1f, "0");
                offsetInAnimation.Duration = TimeSpan.FromMilliseconds(250);


                KeyFrameAnimation fadeAnimation = _compositor.CreateScalarKeyFrameAnimation();
                fadeAnimation.InsertExpressionKeyFrame(1f, "1");
                fadeAnimation.Duration = TimeSpan.FromMilliseconds(250);


                visual.StartAnimation("Offset.X", offsetInAnimation);
                visual.StartAnimation("Opacity", fadeAnimation);

                await Task.Delay(fadeAnimation.Duration);
            }
        }

        internal async static Task AnimatePageOutReverse(Frame frame)
        {
            if (frame.Content is FrameworkElement page)
            {
                if (_compositor == null)
                    _compositor = ElementCompositionPreview.GetElementVisual(page).Compositor;

                var visual = ElementCompositionPreview.GetElementVisual(page);



                string offsetToUse = $"{frame.ActualWidth}";

                KeyFrameAnimation offsetInAnimation = _compositor.CreateScalarKeyFrameAnimation();
                offsetInAnimation.InsertExpressionKeyFrame(1f, offsetToUse);
                offsetInAnimation.Duration = TimeSpan.FromMilliseconds(250);

                KeyFrameAnimation fadeAnimation = _compositor.CreateScalarKeyFrameAnimation();
                fadeAnimation.InsertExpressionKeyFrame(1f, "0");
                fadeAnimation.Duration = TimeSpan.FromMilliseconds(250);

                visual.StartAnimation("Offset.X", offsetInAnimation);
                visual.StartAnimation("Opacity", fadeAnimation);
                await Task.Delay(fadeAnimation.Duration);
            }
        }

        internal async static Task AnimatePageIn(Frame frame)
        {
            if (frame.Content is FrameworkElement page)
            {
                if (_compositor == null)
                    _compositor = ElementCompositionPreview.GetElementVisual(page).Compositor;

                var visual = ElementCompositionPreview.GetElementVisual(page);

                visual.Offset = new Vector3(140, 0, 0);
                visual.Opacity = 0f;
                visual.Scale = new Vector3(1, 1, 0);

                KeyFrameAnimation offsetInAnimation = _compositor.CreateScalarKeyFrameAnimation();
                offsetInAnimation.InsertExpressionKeyFrame(1f, "0");
                offsetInAnimation.Duration = TimeSpan.FromMilliseconds(250);


                KeyFrameAnimation fadeAnimation = _compositor.CreateScalarKeyFrameAnimation();
                fadeAnimation.InsertExpressionKeyFrame(1f, "1");
                fadeAnimation.Duration = TimeSpan.FromMilliseconds(250);


                visual.StartAnimation("Offset.X", offsetInAnimation);
                visual.StartAnimation("Opacity", fadeAnimation);
                await Task.Delay(fadeAnimation.Duration);
            }


        }

        internal async static Task AnimatePageOut(Frame frame)
        {
            if (frame.Content is FrameworkElement page)
            {
                if (_compositor == null)
                    _compositor = ElementCompositionPreview.GetElementVisual(page).Compositor;

                var visual = ElementCompositionPreview.GetElementVisual(page);


                KeyFrameAnimation offsetInAnimation = _compositor.CreateScalarKeyFrameAnimation();


                string offsetToUse = $"-{frame.ActualWidth}";
                offsetInAnimation.InsertExpressionKeyFrame(1f, offsetToUse);
                offsetInAnimation.Duration = TimeSpan.FromMilliseconds(250);

                KeyFrameAnimation fadeAnimation = _compositor.CreateScalarKeyFrameAnimation();
                fadeAnimation.InsertExpressionKeyFrame(1f, "0");
                fadeAnimation.Duration = TimeSpan.FromMilliseconds(200);

                visual.StartAnimation("Offset.X", offsetInAnimation);
                visual.StartAnimation("Opacity", fadeAnimation);
                await Task.Delay(offsetInAnimation.Duration);
            }
        }

        internal async static Task FastSildeIn(Frame frame)
        {
            if (frame.Content is Page page)
            {
                //frame.Background = page.Background;
                if (_compositor == null)
                    _compositor = ElementCompositionPreview.GetElementVisual(page).Compositor;

                var visual = ElementCompositionPreview.GetElementVisual(page);
                visual.Offset = new Vector3((float)frame.ActualWidth - 140, 0, 0);

                KeyFrameAnimation offsetInAnimation = _compositor.CreateScalarKeyFrameAnimation();
                offsetInAnimation.InsertExpressionKeyFrame(1f, "0");
                offsetInAnimation.Duration = TimeSpan.FromMilliseconds(300);




                visual.StartAnimation("Offset.X", offsetInAnimation);
                await Task.Delay(offsetInAnimation.Duration);
            }
        }

        internal async static Task FastSlideOut(Frame frame)
        {
            if (frame.Content is Page page)
            {
                if (page.Background != null)
                {
                    frame.Background = page.Background;
                }

                else if (page.Content is Panel panel)
                {
                    if (panel.Background != null)
                    {
                        frame.Background = panel.Background;
                    }
                    else
                    {
                        frame.Background = (SolidColorBrush)Application.Current.Resources[systemBackgroundColourKey];
                    }
                }

                if (_compositor == null)
                    _compositor = ElementCompositionPreview.GetElementVisual(page).Compositor;

                var visual = ElementCompositionPreview.GetElementVisual(page);


                KeyFrameAnimation offsetInAnimation = _compositor.CreateScalarKeyFrameAnimation();

                string offsetToUse = $"-{140}";
                offsetInAnimation.InsertExpressionKeyFrame(1f, offsetToUse);
                offsetInAnimation.Duration = TimeSpan.FromMilliseconds(300);


                visual.StartAnimation("Offset.X", offsetInAnimation);
                await Task.Delay(100);
            }
        }

        internal async static Task FastSlideInReverse(Frame frame)
        {
            if (frame.Content is Page page)
            {
                if (_compositor == null)
                    _compositor = ElementCompositionPreview.GetElementVisual(page).Compositor;

                var visual = ElementCompositionPreview.GetElementVisual(page);
                visual.Offset = new Vector3(-((float)frame.ActualWidth - 140), 0, 0);

                KeyFrameAnimation offsetInAnimation = _compositor.CreateScalarKeyFrameAnimation();
                offsetInAnimation.InsertExpressionKeyFrame(1f, "0");
                offsetInAnimation.Duration = TimeSpan.FromMilliseconds(300);




                visual.StartAnimation("Offset.X", offsetInAnimation);
                await Task.Delay(offsetInAnimation.Duration);
            }
        }

        internal async static Task FastSlideOutReverse(Frame frame)
        {
            if (frame.Content is Page page)
            {
                if (page.Background != null)
                {
                    frame.Background = page.Background;
                }

                else if (page.Content is Panel panel)
                {
                    if (panel.Background != null)
                    {
                        frame.Background = panel.Background;
                    }
                    else
                    {
                        frame.Background = (SolidColorBrush)Application.Current.Resources[systemBackgroundColourKey];
                    }
                }

                if (_compositor == null)
                    _compositor = ElementCompositionPreview.GetElementVisual(page).Compositor;

                var visual = ElementCompositionPreview.GetElementVisual(page);


                KeyFrameAnimation offsetInAnimation = _compositor.CreateScalarKeyFrameAnimation();

                string offsetToUse = $"{140}";
                offsetInAnimation.InsertExpressionKeyFrame(1f, offsetToUse);
                offsetInAnimation.Duration = TimeSpan.FromMilliseconds(300);


                visual.StartAnimation("Offset.X", offsetInAnimation);
                await Task.Delay(100);
            }
        }

        internal async static Task ColorTransitionIn(Frame frame)
        {
            if (frame.Content is Page page)
            {
                if (_compositor == null)
                    _compositor = ElementCompositionPreview.GetElementVisual(page).Compositor;

                var visual = ElementCompositionPreview.GetElementVisual(page);

                visual.Opacity = 0f;



                KeyFrameAnimation opacityAnimation = _compositor.CreateScalarKeyFrameAnimation();
                opacityAnimation.InsertExpressionKeyFrame(1f, "1");
                opacityAnimation.Duration = TimeSpan.FromMilliseconds(1000);

                visual.StartAnimation("Opacity", opacityAnimation);
                await Task.Delay(opacityAnimation.Duration);
            }
        }

        internal async static Task ColorTransitionOut(Frame frame)
        {
            if (frame.Content is Page page)
            {
                if (page.Background != null)
                {
                    frame.Background = page.Background;
                }

                else if (page.Content is Panel panel)
                {
                    if (panel.Background != null)
                    {
                        frame.Background = panel.Background;
                    }
                    else
                    {
                        frame.Background = (SolidColorBrush)Application.Current.Resources[systemBackgroundColourKey];
                    }
                }
                var visual = ElementCompositionPreview.GetElementVisual(page);

                KeyFrameAnimation opacityAnimation = _compositor.CreateScalarKeyFrameAnimation();
                opacityAnimation.InsertExpressionKeyFrame(1f, "0");
                opacityAnimation.Duration = TimeSpan.FromMilliseconds(1000);

                var sv = _compositor.CreateSpriteVisual();
                sv.Brush = _compositor.CreateColorBrush(Colors.LimeGreen);

                visual.StartAnimation("Opacity", opacityAnimation);
                await Task.Delay(333);

            }

        }


    }
}
