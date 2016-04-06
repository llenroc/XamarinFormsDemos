﻿using Wortell.XamarinForms.Behaviors.Base;
using Xamarin.Forms;

namespace Wortell.XamarinForms.Behaviors
{
  public class AnimateSlideInBehavior : AnimateFoldBehaviorBase
  {
    protected override void Init(bool newValue)
    {
      if (newValue)
      {
        var parentView = GetParentView();
        if (parentView != null)
        {
          FoldInPosition = -parentView.Width;
          AssociatedObject.TranslationX = FoldInPosition;
        }
      }
    }

    protected override void ExecuteAnimation(double start, double end, uint runningTime)
    {
      var animation = new Animation(
        d => AssociatedObject.TranslationX = d, start, end, Easing.SinOut);

      animation.Commit(AssociatedObject, "Unfold", length: runningTime,
        finished: (d, b) =>
        {
          if (AssociatedObject.TranslationX.Equals(FoldInPosition))
          {
            AssociatedObject.IsVisible = false;
          }
        });
    }
  }
}