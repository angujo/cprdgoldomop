using System;

namespace Util
{
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; protected set; }

        public StringValueAttribute(string v) { StringValue = v; }
    }
}
