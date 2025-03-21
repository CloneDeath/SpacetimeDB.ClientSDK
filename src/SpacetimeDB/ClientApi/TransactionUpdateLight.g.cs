// THIS FILE IS AUTOMATICALLY GENERATED BY SPACETIMEDB. EDITS TO THIS FILE
// WILL NOT BE SAVED. MODIFY TABLES IN YOUR MODULE SOURCE CODE INSTEAD.

#nullable enable

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SpacetimeDB.ClientApi
{
    [SpacetimeDB.Type]
    [DataContract]
    public sealed partial class TransactionUpdateLight
    {
        [DataMember(Name = "request_id")]
        public uint RequestId;
        [DataMember(Name = "update")]
        public DatabaseUpdate Update;

        public TransactionUpdateLight(
            uint RequestId,
            DatabaseUpdate Update
        )
        {
            this.RequestId = RequestId;
            this.Update = Update;
        }

        public TransactionUpdateLight()
        {
            this.Update = new();
        }
    }
}
