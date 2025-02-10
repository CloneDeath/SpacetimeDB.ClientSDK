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
    public sealed partial class TransactionUpdate
    {
        [DataMember(Name = "status")]
        public UpdateStatus Status;
        [DataMember(Name = "timestamp")]
        public SpacetimeDB.Timestamp Timestamp;
        [DataMember(Name = "caller_identity")]
        public SpacetimeDB.Identity CallerIdentity;
        [DataMember(Name = "caller_connection_id")]
        public SpacetimeDB.ConnectionId CallerConnectionId;
        [DataMember(Name = "reducer_call")]
        public ReducerCallInfo ReducerCall;
        [DataMember(Name = "energy_quanta_used")]
        public EnergyQuanta EnergyQuantaUsed;
        [DataMember(Name = "total_host_execution_duration")]
        public SpacetimeDB.TimeDuration TotalHostExecutionDuration;

        public TransactionUpdate(
            UpdateStatus Status,
            SpacetimeDB.Timestamp Timestamp,
            SpacetimeDB.Identity CallerIdentity,
            SpacetimeDB.ConnectionId CallerConnectionId,
            ReducerCallInfo ReducerCall,
            EnergyQuanta EnergyQuantaUsed,
            SpacetimeDB.TimeDuration TotalHostExecutionDuration
        )
        {
            this.Status = Status;
            this.Timestamp = Timestamp;
            this.CallerIdentity = CallerIdentity;
            this.CallerConnectionId = CallerConnectionId;
            this.ReducerCall = ReducerCall;
            this.EnergyQuantaUsed = EnergyQuantaUsed;
            this.TotalHostExecutionDuration = TotalHostExecutionDuration;
        }

        public TransactionUpdate()
        {
            this.Status = null!;
            this.ReducerCall = new();
            this.EnergyQuantaUsed = new();
        }
    }
}
