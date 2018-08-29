﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace Flow_Frame.Services
{
    internal class AnimationService
    {
        private static Compositor _compositor;

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
            if (frame.Content is FrameworkElement page)
            {
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
            if (frame.Content is FrameworkElement page)
            {
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
    }


}
