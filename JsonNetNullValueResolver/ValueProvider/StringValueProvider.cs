using Newtonsoft.Json.Serialization;
using System;

namespace JsonNetNullValueResolver.ValueProvider
{
    #region "字符串类型提供器"
    /// <summary>
    /// 字符串值类型提供器
    /// Author: 毛文君
    /// Date:2016-07-03
    /// email:dot888@qq.com
    /// </summary>
    class StringValueProvider : IValueProvider
    {
        private IValueProvider innerProvider;
        private object defaultValue;

        public StringValueProvider(IValueProvider innerProvider, Type stringType)
        {
            this.innerProvider = innerProvider;
            defaultValue = string.Empty;
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
