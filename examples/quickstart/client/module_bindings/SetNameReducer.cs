// THIS FILE IS AUTOMATICALLY GENERATED BY SPACETIMEDB. EDITS TO THIS FILE
// WILL NOT BE SAVED. MODIFY TABLES IN RUST INSTEAD.

using System;
using ClientApi;
using Newtonsoft.Json.Linq;
using SpacetimeDB;

namespace SpacetimeDB.Types
{
	public static partial class Reducer
	{
		public delegate void SetNameHandler(ReducerEvent reducerEvent, string name);
		public static event SetNameHandler OnSetNameEvent;

		public static void SetName(string name)
		{
			var _argArray = new object[] {name};
			var _message = new SpacetimeDBClient.ReducerCallRequest {
				fn = "set_name",
				args = _argArray,
			};
			SpacetimeDBClient.instance.InternalCallReducer(Newtonsoft.Json.JsonConvert.SerializeObject(_message, _settings));
		}

		[ReducerCallback(FunctionName = "set_name")]
		public static bool OnSetName(ClientApi.Event dbEvent)
		{
			if(OnSetNameEvent != null)
			{
				var args = ((ReducerEvent)dbEvent.FunctionCall.CallInfo).SetNameArgs;
				OnSetNameEvent((ReducerEvent)dbEvent.FunctionCall.CallInfo
					,(string)args.Name
				);
				return true;
			}
			return false;
		}

		[DeserializeEvent(FunctionName = "set_name")]
		public static void SetNameDeserializeEventArgs(ClientApi.Event dbEvent)
		{
			var args = new SetNameArgsStruct();
			var bsatnBytes = dbEvent.FunctionCall.ArgBytes;
			using var ms = new System.IO.MemoryStream();
			ms.SetLength(bsatnBytes.Length);
			bsatnBytes.CopyTo(ms.GetBuffer(), 0);
			ms.Position = 0;
			using var reader = new System.IO.BinaryReader(ms);
			var args_0_value = SpacetimeDB.SATS.AlgebraicValue.Deserialize(SpacetimeDB.SATS.AlgebraicType.CreatePrimitiveType(SpacetimeDB.SATS.BuiltinType.Type.String), reader);
			args.Name = args_0_value.AsString();
			dbEvent.FunctionCall.CallInfo = new ReducerEvent(ReducerType.SetName, "set_name", dbEvent.Timestamp, Identity.From(dbEvent.CallerIdentity.ToByteArray()), Address.From(dbEvent.CallerAddress.ToByteArray()), dbEvent.Message, dbEvent.Status, args);
		}
	}

	public partial class SetNameArgsStruct
	{
		public string Name;
	}

}
