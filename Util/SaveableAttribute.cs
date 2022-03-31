using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SaveableAttribute : Attribute
    {
        public bool AllowSave { get; private set; }

        public SaveableAttribute(bool saveable) { AllowSave = saveable; }
    }
}
