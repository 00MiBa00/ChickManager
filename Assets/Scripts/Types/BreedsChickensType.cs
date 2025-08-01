using System;
using System.ComponentModel;

namespace Types
{
    public enum BreedsChickensType
    {
        [Description("Leghorn")]
        Leghorn,

        [Description("Rhode Island Red")]
        RhodeIslandRed,

        [Description("Orpington")]
        Orpington,

        [Description("Plymouth Rock")]
        PlymouthRock,

        [Description("Sussex")]
        Sussex
    }
    
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}