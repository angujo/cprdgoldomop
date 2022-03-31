using System;

namespace Util
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SaveableAttribute : Attribute
    {
        public bool AllowSave { get; private set; }

        public SaveableAttribute(bool saveable) { AllowSave = saveable; }
    }
}
