using System;

namespace Bookworm.BAL.Core.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DisplayNameAttribute : Attribute
    {
        public DisplayNameAttribute(string name) => Name = name;

        public string Name{ get; }
    }
}
