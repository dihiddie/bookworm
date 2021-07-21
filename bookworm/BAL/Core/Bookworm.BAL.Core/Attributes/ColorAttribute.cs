using Bookworm.BAL.Core.Enums;
using System;

namespace Bookworm.BAL.Core.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class ColorAttribute : Attribute
    {

        public ColorAttribute(ColorEnum color) => Color = color;

        public ColorEnum Color { get; }
    }
}