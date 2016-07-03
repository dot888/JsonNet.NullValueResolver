using Newtonsoft.Json.Serialization;
using System;

namespace JsonNetNullValueResolver.ValueProvider
{
    #region "集合类型提供器"
    /// <summary>
    /// 空集合值提供器
    /// Author: 毛文君
    /// Date:2016-07-03
    /// email:dot888@qq.com
    /// </summary>
    class EmptyCollectionValueProvider : IValueProvider
    {
        private IValueProvider innerProvider;
        private object defaultValue;

        public EmptyCollectionValueProvider(IValueProvider innerProvider, Type listType)
        {
            this.innerProvider = innerProvider;
            defaultValue = Activator.CreateInstance(listType, 0);
        }

        public void SetValue(object target, object value)
        {
            innerProvider.SetValue(target, value ?? defaultValue);
        }

        public object GetValue(object target)
        {
            return innerProvider.GetValue(target) ?? defaultValue;
        }
    }
    #endregion
}
