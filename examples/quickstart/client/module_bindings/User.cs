// THIS FILE IS AUTOMATICALLY GENERATED BY SPACETIMEDB. EDITS TO THIS FILE
// WILL NOT BE SAVED. MODIFY TABLES IN RUST INSTEAD.

using System;
using System.Collections.Generic;
using SpacetimeDB;

namespace SpacetimeDB.Types
{
	[Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
	public partial class User : IDatabaseTable
	{
		[Newtonsoft.Json.JsonProperty("identity")]
		public SpacetimeDB.Identity Identity;
		[Newtonsoft.Json.JsonProperty("name")]
		[SpacetimeDB.Some]
		public string Name;
		[Newtonsoft.Json.JsonProperty("online")]
		public bool Online;

		private static Dictionary<SpacetimeDB.Identity, User> Identity_Index = new Dictionary<SpacetimeDB.Identity, User>(16);

		private static void InternalOnValueInserted(object insertedValue)
		{
			var val = (User)insertedValue;
			Identity_Index[val.Identity] = val;
		}

		private static void InternalOnValueDeleted(object deletedValue)
		{
			var val = (User)deletedValue;
			Identity_Index.Remove(val.Identity);
		}

		public static SpacetimeDB.SATS.AlgebraicType GetAlgebraicType()
		{
			return SpacetimeDB.SATS.AlgebraicType.CreateProductType(new SpacetimeDB.SATS.ProductTypeElement[]
			{
				new SpacetimeDB.SATS.ProductTypeElement("identity", SpacetimeDB.SATS.AlgebraicType.CreateProductType(new SpacetimeDB.SATS.ProductTypeElement[]
			{
				new SpacetimeDB.SATS.ProductTypeElement("__identity_bytes", SpacetimeDB.SATS.AlgebraicType.CreateArrayType(SpacetimeDB.SATS.AlgebraicType.CreatePrimitiveType(SpacetimeDB.SATS.BuiltinType.Type.U8))),
			})),
				new SpacetimeDB.SATS.ProductTypeElement("name", SpacetimeDB.SATS.AlgebraicType.CreateSumType(new System.Collections.Generic.List<SpacetimeDB.SATS.SumTypeVariant>
			{
				new SpacetimeDB.SATS.SumTypeVariant("some", SpacetimeDB.SATS.AlgebraicType.CreatePrimitiveType(SpacetimeDB.SATS.BuiltinType.Type.String)),
				new SpacetimeDB.SATS.SumTypeVariant("none", SpacetimeDB.SATS.AlgebraicType.CreateProductType(new SpacetimeDB.SATS.ProductTypeElement[]
			{
			})),
			})),
				new SpacetimeDB.SATS.ProductTypeElement("online", SpacetimeDB.SATS.AlgebraicType.CreatePrimitiveType(SpacetimeDB.SATS.BuiltinType.Type.Bool)),
			});
		}

		public static explicit operator User(SpacetimeDB.SATS.AlgebraicValue value)
		{
			if (value == null) {
				return null;
			}
			var productValue = value.AsProductValue();
			return new User
			{
				Identity = SpacetimeDB.Identity.From(productValue.elements[0].AsProductValue().elements[0].AsBytes()),
				Name = productValue.elements[1].AsSumValue().tag == 1 ? null : productValue.elements[1].AsSumValue().value.AsString(),
				Online = productValue.elements[2].AsBool(),
			};
		}

		public static System.Collections.Generic.IEnumerable<User> Iter()
		{
			foreach(var entry in SpacetimeDBClient.clientDB.GetEntries("User"))
			{
				yield return (User)entry.Item2;
			}
		}
		public static int Count()
		{
			return SpacetimeDBClient.clientDB.Count("User");
		}
		public static User FilterByIdentity(SpacetimeDB.Identity value)
		{
			Identity_Index.TryGetValue(value, out var r);
			return r;
		}

		public static System.Collections.Generic.IEnumerable<User> FilterByName(string? value)
		{
			foreach(var entry in SpacetimeDBClient.clientDB.GetEntries("User"))
			{
				var productValue = entry.Item1.AsProductValue();
				var compareValue = (string?)(productValue.elements[1].AsSumValue().tag == 1 ? null : productValue.elements[1].AsSumValue().value.AsString());
				if (compareValue == value) {
					yield return (User)entry.Item2;
				}
			}
		}

		public static System.Collections.Generic.IEnumerable<User> FilterByOnline(bool value)
		{
			foreach(var entry in SpacetimeDBClient.clientDB.GetEntries("User"))
			{
				var productValue = entry.Item1.AsProductValue();
				var compareValue = (bool)productValue.elements[2].AsBool();
				if (compareValue == value) {
					yield return (User)entry.Item2;
				}
			}
		}

		public static bool ComparePrimaryKey(SpacetimeDB.SATS.AlgebraicType t, SpacetimeDB.SATS.AlgebraicValue v1, SpacetimeDB.SATS.AlgebraicValue v2)
		{
			var primaryColumnValue1 = v1.AsProductValue().elements[0];
			var primaryColumnValue2 = v2.AsProductValue().elements[0];
			return SpacetimeDB.SATS.AlgebraicValue.Compare(t.product.elements[0].algebraicType, primaryColumnValue1, primaryColumnValue2);
		}

		public static SpacetimeDB.SATS.AlgebraicValue GetPrimaryKeyValue(SpacetimeDB.SATS.AlgebraicValue v)
		{
			return v.AsProductValue().elements[0];
		}

		public static SpacetimeDB.SATS.AlgebraicType GetPrimaryKeyType(SpacetimeDB.SATS.AlgebraicType t)
		{
			return t.product.elements[0].algebraicType;
		}

		public delegate void InsertEventHandler(User insertedValue, SpacetimeDB.Types.ReducerEvent dbEvent);
		public delegate void UpdateEventHandler(User oldValue, User newValue, SpacetimeDB.Types.ReducerEvent dbEvent);
		public delegate void DeleteEventHandler(User deletedValue, SpacetimeDB.Types.ReducerEvent dbEvent);
		public delegate void RowUpdateEventHandler(SpacetimeDBClient.TableOp op, User oldValue, User newValue, SpacetimeDB.Types.ReducerEvent dbEvent);
		public static event InsertEventHandler OnInsert;
		public static event UpdateEventHandler OnUpdate;
		public static event DeleteEventHandler OnBeforeDelete;
		public static event DeleteEventHandler OnDelete;
		public static event RowUpdateEventHandler OnRowUpdate;

		public static void OnInsertEvent(object newValue, ClientApi.Event dbEvent)
		{
			OnInsert?.Invoke((User)newValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}

		public static void OnUpdateEvent(object oldValue, object newValue, ClientApi.Event dbEvent)
		{
			OnUpdate?.Invoke((User)oldValue,(User)newValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}

		public static void OnBeforeDeleteEvent(object oldValue, ClientApi.Event dbEvent)
		{
			OnBeforeDelete?.Invoke((User)oldValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}

		public static void OnDeleteEvent(object oldValue, ClientApi.Event dbEvent)
		{
			OnDelete?.Invoke((User)oldValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}

		public static void OnRowUpdateEvent(SpacetimeDBClient.TableOp op, object oldValue, object newValue, ClientApi.Event dbEvent)
		{
			OnRowUpdate?.Invoke(op, (User)oldValue,(User)newValue,(ReducerEvent)dbEvent?.FunctionCall.CallInfo);
		}
	}
}
