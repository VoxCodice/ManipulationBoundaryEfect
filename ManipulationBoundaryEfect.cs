using System.Windows;
using System.Windows.Controls;

namespace ManipulationBoundaryEfect
{
    public class ManipulationBoundaryEfect
    {
        private static readonly RoutedEventHandler manipulationBoundaryFeedbackEvent = new RoutedEventHandler(OnManipulationBoundaryFeedback);

        public static readonly DependencyProperty DisabledProperty =
            DependencyProperty.RegisterAttached("Disabled",
                                                typeof(bool),
                                                typeof(ManipulationBoundaryEfect),
                                                new PropertyMetadata(false, DisableManipulationBoundaryEfectChanged));

        public static void SetDisabled(UIElement element, bool value)
        {
            element.SetValue(DisabledProperty, value);
        }

        public static bool GetDisabled(UIElement element)
        {
            return (bool)element.GetValue(DisabledProperty);
        }

        private static void DisableManipulationBoundaryEfectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ScrollViewer element)
                return;

            if ((bool)e.NewValue == true)
                element.AddHandler(UIElement.ManipulationBoundaryFeedbackEvent, manipulationBoundaryFeedbackEvent);
            else
                element.RemoveHandler(UIElement.ManipulationBoundaryFeedbackEvent, manipulationBoundaryFeedbackEvent);
        }

        private static void OnManipulationBoundaryFeedback(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
