using UnityEngine.UIElements;

namespace Depra.Common.Unity.Runtime.Extensions.UI
{
    /// <summary>
    /// <see cref="FocusController"/> extensions.
    /// </summary>
    public static class FocusControllerExtensions
    {
        /// <summary>
        /// Checks whether a field that can receive input is focused.
        /// </summary>
        public static bool IsInputFieldFocused(this FocusController focusController)
        {
            return focusController.focusedElement is VisualElement visualElement && visualElement
                .Query<TextElement>(null, "unity-text-element--inner-input-field-component")
                .Focused()
                .Build()
                .First() != null;
        }
    }
}