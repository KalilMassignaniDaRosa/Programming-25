using System.Collections.Generic;

namespace _05_VeterinaryActivity.Models
{
    public class ClassInfo
    {
        public string ClassName { get; set; } = string.Empty;
        public string BaseClass { get; set; } = string.Empty;
        public List<MethodDetail> Methods { get; set; } = new();
        public List<PropertyDetail> Properties { get; set; } = new();
        public List<FieldDetail> Fields { get; set; } = new();
    }

    public class MethodDetail
    {
        public string Name { get; set; } = string.Empty;          
        public string Accessibility { get; set; } = string.Empty;
        public string ReturnType { get; set; } = string.Empty;   
    }

    public class PropertyDetail
    {
        public string Name { get; set; } = string.Empty;
        public string PropertyType { get; set; } = string.Empty;
        public string Accessibility { get; set; } = string.Empty;
    }

    public class FieldDetail
    {
        public string Name { get; set; } = string.Empty;
        public string FieldType { get; set; } = string.Empty;
        public string Accessibility { get; set; } = string.Empty;
    }
}