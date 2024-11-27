#if ANDROID
using Android.App;
using Android.Content;
using Android.Views.InputMethods;
#elif IOS
using UIKit;
#endif

namespace BudgetApp.Resources.Helpers
{
    public static class KeyboardHelperClass
    {
        public static double GetKeyboardHeight()
        {
#if ANDROID
                var context = Android.App.Application.Context;
                var inputMethodManager = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
                var height = GetInputMethodWindowVisibleHeight(inputMethodManager);

                return height / context.Resources.DisplayMetrics.Density; // Convert pixels to DP
#elif IOS
                double keyboardHeight = 0;
                UIKit.UIKeyboard.Notifications.ObserveDidShow((sender, args) =>
                {
                    var keyboardFrame = args.FrameEnd;
                    keyboardHeight = keyboardFrame.Height;
                });
                return keyboardHeight;
#else
            return 0; // Default for unsupported platforms
#endif
        }

#if ANDROID
            private static int GetInputMethodWindowVisibleHeight(InputMethodManager imm)
            {
                // Use reflection to get the height as InputMethodWindowVisibleHeight is not a public property
                var method = imm.Class.GetMethod("getInputMethodWindowVisibleHeight");
                return (int)method.Invoke(imm);
            }
#endif
    }
}