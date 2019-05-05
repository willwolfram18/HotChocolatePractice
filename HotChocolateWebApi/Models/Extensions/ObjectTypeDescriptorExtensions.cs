using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using HotChocolate.Types;
using NJsonSchema.Infrastructure;

namespace HotChocolateWebApi.Models.Extensions
{
    public static class ObjectTypeDescriptorExtensions
    {
        private static Dictionary<Type, IInputType> _typeMappings = new Dictionary<Type, IInputType>
        {
            { typeof(string), new StringType() }
        };

        public static IObjectTypeDescriptor<T> DescriptionFromXmlSummary<T>(this IObjectTypeDescriptor<T> descriptor)
        {
            return descriptor.Description(
                typeof(T).GetXmlSummaryAsync()
                    .GetAwaiter()
                    .GetResult()
            );
        }

        public static IObjectFieldDescriptor FieldWitDescriptionFromXmlSummary<T>(this IObjectTypeDescriptor<T> descriptor,
            Expression<Func<T, object>> field)
        {
            var xmlSummary = string.Empty;
            var fieldDescriptor = descriptor.Field(field);

            switch (field.Body)
            {
                case MemberExpression m:
                    xmlSummary = m.Member.GetXmlSummaryAsync().GetAwaiter().GetResult();
                    break;
                case MethodCallExpression m:
                    xmlSummary = m.Method.GetXmlSummaryAsync().GetAwaiter().GetResult();

                    foreach (var param in m.Method.GetParameters())
                    {
                        // TODO: Need a way to provide a description without the Type() mapping
                        fieldDescriptor.Argument(
                            param.Name,
                            a => a.Description(
                                param.GetXmlDocumentationAsync()
                                    .GetAwaiter()
                                    .GetResult()
                            ).Type(Map(param))
                        );
                    }

                    break;
            }

            return fieldDescriptor
                .Description(xmlSummary);
        }

        private static IInputType Map(ParameterInfo param)
        {
            if (!_typeMappings.ContainsKey(param.ParameterType))
            {
                throw new KeyNotFoundException($"Unable to find GraphQL input type for type {param.ParameterType}.");
            }

            return _typeMappings[param.ParameterType];
        }
    }
}