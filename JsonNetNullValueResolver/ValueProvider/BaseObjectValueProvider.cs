using Newtonsoft.Json.Serialization;
using System;

namespace JsonNetNullValueResolver.ValueProvider
{
    #region "基类Object类型提供器"
    /// <summary>
    /// 基类型Object值转换器
    /// Author: 毛文君
    /// Date:2016-07-03
    /// email:dot888@qq.com
    /// </summary>
    public class BaseObjectValueProvider : IValueProvider
    {
        private IValueProvider innerProvider;
        private object defaultValue;

        public BaseObjectValueProvider(IValueProvider innerProvider, Type valueType)
        {
            this.innerProvider = innerProvider;

            defaultValue = Activator.CreateInstance(valueType);
        }

        public object GetValue(object target)
        {
            return innerProvider.GetValue(target) ?? defaultValue;
        }

        public void SetValue(object target, object value)
        {
            innerProvider.SetValue(target, value ?? defaultValue);
        }
    }
    #endregion
}
