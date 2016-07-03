using JsonNetNullValueResolver;
using JsonNetNullValueResolver.Converters;
using JsonNetNullValueResolver.ValueProvider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    /// <summary>
    /// Autho:毛文君
    /// Date:2016-07-03
    /// email:dot888@qq.com
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var responseModel = new[] { new ResponseModel() };
            responseModel[0].IsSuccess = true;

            //Entity --> null
            responseModel[0].Entity = null;


            // JsonNet Configuration
            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new NullValueResolver();
                return settings;
            });


            Console.WriteLine("Before Serialize：");
            Console.Write("TestDate:");
            responseModel[0].TestDate = DateTime.Now;
            Console.WriteLine(responseModel[0].TestDate);

            Console.WriteLine("----------------------------");

            //serialize object to json
            var jsonResult = JsonConvert.SerializeObject(responseModel);
            Console.WriteLine(jsonResult);


            Console.WriteLine("----------------------------");

            //deserialize json string to object
            var inputJsonResult = JsonConvert.DeserializeAnonymousType(jsonResult, responseModel);
            Console.WriteLine("After Deserialized：");
            Console.Write("TestDate:");
            Console.WriteLine(inputJsonResult[0].TestDate);

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 测试类
    /// </summary>
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }

        public object Entity { get; set; }

        [JsonConverter(typeof(UnixTimeStampDateTimeConverter))]
        public DateTime TestDate { get; set; }

        public DateTime? NullableDate { get; set; }

        public bool? NullableBool { get; set; }
        public Guid? NullableGuid { get; set; }
    }
}
