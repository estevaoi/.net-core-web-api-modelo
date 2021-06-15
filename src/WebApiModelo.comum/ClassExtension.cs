using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiModelo.comum
{
    public static class ClassExtension
    {
        public static T Cast<T>(this object obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }
    }
}