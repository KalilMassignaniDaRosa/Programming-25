using System;
using System.Collections.Generic;
using System.Linq;
// Reflection permite ler os metadados das classes 
using System.Reflection;

namespace _05_VeterinaryActivity.Models
{
    public class ClassInfoService
    {
        public ClassInfo GetClassInfo(Type classType)
        {
            return new ClassInfo
            {
                ClassName = classType.Name,
                BaseClass = GetBaseClassName(classType),
                Methods = GetMethods(classType),
                Properties = GetProperties(classType),
                Fields = GetFields(classType)
            };

        }

        private string GetBaseClassName(Type classType)
        {
            // BaseType retorna a classe pai
            Type baseType = classType.BaseType!;
            if (baseType == null || baseType == typeof(object))
                return string.Empty;

            return baseType.Name;
        }

        private string GetTypeName(Type type)
        {
            // Se for Nullable<T> retorna T
            // GetGenericTypeDefinition() remove parametros genericos e retorna o tipo base
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type underlying = Nullable.GetUnderlyingType(type)!;
                return underlying.Name;
            }

            if (type.IsGenericType)
            {
                // Pega o nome base antes do sufixo `
                // O compilador adiciona numeros como `1`, `2` para indicar a quantidade de parametros genericos
                string baseName = type.Name.Substring(0, type.Name.IndexOf('`'));

                
                Type[] arguments = type.GetGenericArguments();
                List<string> argumentNames = new();
                // Chama o metodo recursivamente
                foreach (Type t in arguments)
                {
                    argumentNames.Add(GetTypeName(t));
                }

                return $"{baseName}<{string.Join(", ", argumentNames)}>";
            }

            if (type.IsArray)
            {
                Type elementType = type.GetElementType()!;
                return $"{GetTypeName(elementType)}[]";
            }

            return type.Name;
        }

        private List<MethodDetail> GetMethods(Type classType)
        {
            // Pega todos os metodos da classe
            // O GetMethods e uma funcao da biblioteca Reflection
            // Retorna um array
            MethodInfo[] allMethods = classType.GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
             );

            List<MethodDetail> methodDetails = new();

            foreach (MethodInfo method in allMethods)
            {
                // Ignora herancas
                if (method.DeclaringType != classType)
                    continue;

                // Ignora getters/setters e operadores
                if (method.IsSpecialName)
                    continue;

                MethodDetail detail = new MethodDetail
                {
                    Name = $"{method.Name}()",
                    // Define public, private, protected
                    Accessibility = GetAccessLevel(method), 
                    ReturnType = GetTypeName(method.ReturnType)
                };

                methodDetails.Add(detail); 
            }
            return methodDetails;
        }

        private List<PropertyDetail> GetProperties(Type classType)
        {
            PropertyInfo[] allProperties = classType.GetProperties(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            List<PropertyDetail> propertyDetails = new();

            foreach (PropertyInfo property in allProperties)
            {
                // Ignora heranca
                if (property.DeclaringType != classType)
                    continue;

                PropertyDetail detail = new PropertyDetail
                {
                    Name = property.Name,
                    PropertyType = GetTypeName(property.PropertyType),
                    Accessibility = GetAccessLevel(property)
                };

                propertyDetails.Add(detail);
            }
            return propertyDetails;
        }

        private List<FieldDetail> GetFields(Type classType)
        {
            FieldInfo[] allFields = classType.GetFields(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            List<FieldDetail> fieldDetails = new();

            foreach (FieldInfo field in allFields)
            {
                // Ignora os back-fields
                if (field.Name.Contains("<"))
                    continue;

                FieldDetail detail = new FieldDetail
                {
                    Name = field.Name,
                    FieldType = GetTypeName(field.FieldType),
                    Accessibility = GetAccessLevel(field)
                };

                fieldDetails.Add(detail);
            }
            return fieldDetails;
        }

        // Usando o conceito de sobrecarga de metodos
        private string GetAccessLevel(MethodInfo method)
        {
            // Caso nao seja acessivel de fora
            // Metodos podem ter multiplos nivel de acesso
            if (method == null) 
                return "private";

            // IsFamily retorna true se for protected
            return method.IsPublic ? "public" :
                   method.IsFamily ? "protected" : "private";
        }

        private string GetAccessLevel(PropertyInfo property)
        {
            MethodInfo getter = property.GetMethod!;
            MethodInfo setter = property.SetMethod!;

            if (getter?.IsPublic == true || setter?.IsPublic == true)
                return "public";

            if (getter?.IsFamily == true || setter?.IsFamily == true)
                return "protected";

            return "private";
        }

        private string GetAccessLevel(FieldInfo field)
        {
            return field.IsPublic ? "public" :
                   field.IsFamily ? "protected" : "private";
        }
    }
}