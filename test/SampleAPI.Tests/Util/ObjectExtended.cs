using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Tests.Util
{
    static class ObjectExtended
    {
        public static string Serialize(this object obj)
        {
            return JsonConvert.SerializeObject(
                obj, 
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            );
        }
    }
}
