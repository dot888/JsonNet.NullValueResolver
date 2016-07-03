using Newtonsoft.Json;
using System;
using System.Linq;

namespace JsonNetNullValueResolver.Converters
{
    /// <summary>
    /// Unix时间戳转换器
    /// Author: 毛文君
    /// Date:2016-07-03
    /// </summary>
    public class UnixTimeStampDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(DateTime));
        }

        //反序列化时
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return ConvertTimeStampToDateTime(Convert.ToDouble(reader.Value));
        }

        //序列化时
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // unix时间戳
            writer.WriteValue(ConvertDateTimeToTimeStamp(Convert.ToDateTime(value)).ToString());
        }

        /// <summary>
        /// 将时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d">double 型数字</param>
        /// <returns>DateTime</returns>
        public static System.DateTime ConvertTimeStampToDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            var timeZone = TimeZoneInfo.GetSystemTimeZones().First(m => m.Id == "China Standard Time");
            System.DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), timeZone) +
                                        timeZone.BaseUtcOffset;
            time = startTime.AddSeconds(d);
            return time;
        }

        /// <summary>
        /// 将时期转换为时间戳
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static double ConvertDateTimeToTimeStamp(DateTime date)
        {
            return (date.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
    }
}
