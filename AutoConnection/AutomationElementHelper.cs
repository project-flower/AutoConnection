using System.Windows.Automation;

namespace AutoConnection
{
    public static class AutomationElementHelper
    {
        #region Public Fields

        public static PropertyConditionFlags PropertyConditionFlags = PropertyConditionFlags.None;

        #endregion

        #region Public Methods

        public static bool AnalyzeElement(this AutomationElement element, string className, string controlName, string text = "")
        {
            if (!string.IsNullOrEmpty(className))
            {
                if (!AnalyzeProperty(element, AutomationElement.ClassNameProperty, className))
                {
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(controlName))
            {
                if (!AnalyzeProperty(element, AutomationElement.AutomationIdProperty, controlName))
                {
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(text))
            {
                if (!AnalyzeProperty(element, AutomationElement.NameProperty, text))
                {
                    return false;
                }
            }

            return true;
        }

        public static InvokePattern GetCurrentInvokePattern(this AutomationElement element)
        {
            return element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        }

        public static ValuePattern GetCurrentValuePattern(this AutomationElement element)
        {
            return element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
        }

        //public static bool Invoke(AutomationElement parent, string className, int index)
        //{
        //    AutomationElement element = FindElement(parent, className, index);
        //
        //    if (element == null)
        //    {
        //        return false;
        //    }
        //
        //    if (!element.TryGetCurrentPattern(InvokePattern.Pattern, out object pattern))
        //    {
        //        return false;
        //    }
        //
        //    (pattern as InvokePattern).Invoke();
        //    return true;
        //}

        //public static bool SetValue(AutomationElement parent, string className, int index, string value)
        //{
        //    AutomationElement element = FindElement(parent, className, index);
        //
        //    if (element == null)
        //    {
        //        return false;
        //    }
        //
        //    if (!element.TryGetCurrentPattern(ValuePattern.Pattern, out object valuePattern))
        //    {
        //        return false;
        //    }
        //
        //    (valuePattern as ValuePattern).SetValue(value);
        //    
        //    if (!GetCurrentPattern<ValuePattern>(parent, className, index, out ValuePattern pattern))
        //    {
        //        return false;
        //    }
        //
        //    pattern.SetValue(value);
        //    return true;
        //}

        #endregion

        #region Private Methods

        private static bool AnalyzeProperty(AutomationElement element, AutomationProperty property, string value)
        {
            string propertyValue = element.GetCurrentPropertyValue(property, true) as string;

            if (string.IsNullOrEmpty(propertyValue)) { return false; }

            if (value != propertyValue) { return false; }

            return true;
        }

        //private static bool GetCurrentPattern<T>(AutomationElement parent, string className, int index, out T result)
        //{
        //    AutomationElement element = FindElement(parent, className, index);
        //    result = default;
        //
        //    if (element == null)
        //    {
        //        return false;
        //    }
        //
        //    Type type = typeof(T);
        //    AutomationPattern pattern;
        //
        //    if (type == typeof(ValuePattern))
        //    {
        //        pattern = ValuePattern.Pattern;
        //    }
        //    else if (type == typeof(InvokePattern))
        //    {
        //        pattern = InvokePattern.Pattern;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //
        //    if (!element.TryGetCurrentPattern(pattern, out object patternObject))
        //    {
        //        return false;
        //    }
        //
        //    result = (T)patternObject;
        //    return true;
        //}

        //private static AutomationElement FindElement(AutomationElement parent, string className, int index)
        //{
        //    int i = 0;
        //    AutomationElement found = null;
        //
        //    foreach (AutomationElement element in parent.FindAll(TreeScope.Children, Condition.TrueCondition))
        //    {
        //        if (element.Current.ClassName != className) continue;
        //
        //        if (i == index)
        //        {
        //            found = element;
        //            break;
        //        }
        //
        //        ++i;
        //    }
        //
        //    return found;
        //}

        #endregion
    }
}
