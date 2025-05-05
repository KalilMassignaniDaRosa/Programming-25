namespace _05_VeterinaryActivity.Models
{
    public static class AccessibilityHelper
    {
        public static string CssClass(string accessibility)
        {
            switch (accessibility.ToLower())
            {
                case "public":
                    return "public";
                case "protected":
                    return "protected";
                case "private":
                    return "private";
                default:
                    return "private";
            }
        }

        public static string Symbol(string accessibility)
        {
            switch (accessibility.ToLower())
            {
                case "public":
                    return "+";
                case "protected":
                    return "#";
                case "private":
                    return "-";
                default:
                    return "-";
            }
        }
    }
}
