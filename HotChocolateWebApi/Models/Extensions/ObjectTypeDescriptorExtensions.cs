using System;
using System.Linq.Expressions;
using HotChocolate.Types;
using NJsonSchema.Infrastructure;

namespace HotChocolateWebApi.Models.Extensions
{
    public static class ObjectTypeDescriptorExtensions
    {
        public static IObjectFieldDescriptor AddFieldWithXmlDescription<T>(this IObjectTypeDescriptor<T> descriptor,
            Expression<Func<T, object>> field)
        {
            var xmlSummary = string.Empty;

            switch (field.Body)
            {
                case MemberExpression m:
                    xmlSummary = m.Member.GetXmlSummaryAsync().GetAwaiter().GetResult();
                    break;
                case MethodCallExpression m:
                    xmlSummary = m.Method.GetXmlSummaryAsync().GetAwaiter().GetResult();
                    break;
            }

            return descriptor.Field(field)
                .Description(xmlSummary);
        }
    }
}