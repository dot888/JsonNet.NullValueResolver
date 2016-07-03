using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace JsonNetNullValueResolver.ValueProvider
{
    #region "值类型提供器工厂"
    /// <summary>
    /// 值类型提供器工厂，根据属性类型创建值提供器
    /// Author: 毛文君
    /// Date:2016-07-03
    /// email:dot888@qq.com
    /// </summary>
    public class ValueProviderFactory
    {
        public static IValueProvider GetValueProvider(IValueProvider defaultProvider, Type propType)
        {
            var propertyDataType = GetPropertyDataType(propType);
            switch (propertyDataType)
            {
                case PropertyDataType.StringType:
                    return new StringValueProvider(defaultProvider, propType);
                case PropertyDataType.NumberType:
                    return new NumberValueProvider(defaultProvider, propType);
                case PropertyDataType.BaseObject:
                    return new BaseObjectValueProvider(defaultProvider, propType);
                case PropertyDataType.CollectionType:
                    return new EmptyCollectionValueProvider(defaultProvider, propType);
            }

            return defaultProvider;
        }

        private static bool IsCollection(Type propType)
        {
            return propType.IsGenericType &&
                propType.GetGenericTypeDefinition() == typeof(List<>)
                || propType.IsArray;
        }

        private static bool IsString(Type propType)
        {
            return propType.BaseType != null && propType.IsAssignableFrom(typeof(string));
        }

        private static bool IsNumber(Type propType)
        {
            return propType.IsValueType;
        }

        private static bool IsBaseObject(Type propType)
        {
            return propType.BaseType == null;
        }

        private static PropertyDataType GetPropertyDataType(Type propType)
        {
            if (IsString(propType))
                return PropertyDataType.StringType;

            if (IsNumber(propType))
                return PropertyDataType.NumberType;

            if (IsCollection(propType))
                return PropertyDataType.CollectionType;

            if (IsBaseObject(propType))
                return PropertyDataType.BaseObject;

            return PropertyDataType.Unknown;
        }
    }
    #endregion
}
