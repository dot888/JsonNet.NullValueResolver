using Newtonsoft.Json.Serialization;
using System;

namespace JsonNetNullValueResolver.ValueProvider
{
    #region "数值类型提供器"
    /// <summary>
    /// 数值类型值提供器
    /// Author: 毛文君
    /// Date:2016-07-03
    /// email:dot888@qq.com
    /// </summary>
    class NumberValueProvider : IValueProvider
    {
        private IValueProvider innerProvider;
        private object defaultValue;

        public NumberValueProvider(IValueProvider innerProvider, Type valueType)
        {
            this.innerProvider = innerProvider;

            defaultValue = Activator.CreateInstance(valueType);

            if (defaultValue == null)
            {
                //说明是可空类型
                var realType = valueType.GetGenericArguments()[0];
                defaultValue = Activator.CreateInstance(realType);
            }
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
