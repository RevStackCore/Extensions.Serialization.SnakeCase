using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RevStackCore.Extensions.Serialization.SnakeCase
{
    public static class Json
	{
		public static string SerializeObject<T>(T value)
		{
			DefaultContractResolver contractResolver = new DefaultContractResolver
			{
				NamingStrategy = new SnakeCaseNamingStrategy()
			};

			return JsonConvert.SerializeObject(value, new JsonSerializerSettings
			{
				ContractResolver = contractResolver,
				Formatting = Formatting.Indented

			});
		}

		public static T DeserializeObject<T>(string json)
		{
			DefaultContractResolver contractResolver = new DefaultContractResolver
			{
				NamingStrategy = new SnakeCaseNamingStrategy()
			};

			return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
			{
				ContractResolver = contractResolver,
				Formatting = Formatting.Indented
			});
		}


		public static T Cast<T>(object value)
		{
			var json = SerializeObject(value);
			var obj = DeserializeObject<T>(json);
			return obj;
		}
	}
}

