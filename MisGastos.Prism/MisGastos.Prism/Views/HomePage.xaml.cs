using System;
using Xamarin.Forms;

namespace MisGastos.Prism.Views
{
    public partial class HomePage : ContentPage
    {
        // Important Code Lives Below
        double x, y;
        public HomePage()
        {
            InitializeComponent();
        }

        void OnPanUpdated(System.Object sender, Xamarin.Forms.PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and ensure we don't y + e.TotalY pan beyond the wrapped user interface element bounds.
                    var translateY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs((Height * .25) - Height));
                    bottomSheet.TranslateTo(bottomSheet.X, translateY, 20);
                    break;
                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    y = bottomSheet.TranslationY;

                    //at the end of the event - snap to the closest location
                    var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getClosestLockState(e.TotalY + y)));

                    //depending on Swipe Up or Down - change the snapping animation
                    if (isSwipeUp(e))
                    {
                        bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 250, Easing.SpringIn);
                    }
                    else
                    {
                        bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 250, Easing.SpringOut);
                    }

                    //dismiss the keyboard after a transition
                    //SearchBox.Unfocus();
                    y = bottomSheet.TranslationY;

                    break;

            }
        }

        public bool isSwipeUp(PanUpdatedEventArgs e)
        {
            if (e.TotalY < 0)
            {
                return true;
            }
            return false;
        }

        public double getClosestLockState(double TranslationY)
        {
            //Play with these values to adjust the locking motions - this will change depending on the amount of content ona  apge
            var lockStates = new double[] { 0, .5, .85 };

            //get the current proportion of the sheet in relation to the screen
            var distance = Math.Abs(TranslationY);
            var currentProportion = distance / Height;

            //calculate which lockstate it's the closest to
            var smallestDistance = 10000.0;
            var closestIndex = 0;
            for (var i = 0; i < lockStates.Length; i++)
            {
                var state = lockStates[i];
                var absoluteDistance = Math.Abs(state - currentProportion);
                if (absoluteDistance < smallestDistance)
                {
                    smallestDistance = absoluteDistance;
                    closestIndex = i;
                }
            }

            var selectedLockState = lockStates[closestIndex];
            var TranslateToLockState = getProportionCoordinate(selectedLockState);

            return TranslateToLockState;
        }

        public double getProportionCoordinate(double proportion)
        {
            return proportion * Height;
        }
    }
}
