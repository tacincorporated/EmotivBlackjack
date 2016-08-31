﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("EmotivModel", "fk_EventTypes_pid", "EventType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Logger.EventType), "SavedEvent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Logger.SavedEvent), true)]
[assembly: EdmRelationshipAttribute("EmotivModel", "fk_EventTypesV_pid", "EventType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Logger.EventType), "SavedEventValue", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Logger.SavedEventValue), true)]
[assembly: EdmRelationshipAttribute("EmotivModel", "fk_users_pid", "Participant", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Logger.Participant), "SavedEvent", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Logger.SavedEvent), true)]
[assembly: EdmRelationshipAttribute("EmotivModel", "fk_usersV_pid", "Participant", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Logger.Participant), "SavedEventValue", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Logger.SavedEventValue), true)]

#endregion

namespace Logger
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class EmotivEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new EmotivEntities object using the connection string found in the 'EmotivEntities' section of the application configuration file.
        /// </summary>
        public EmotivEntities() : base("name=EmotivEntities", "EmotivEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new EmotivEntities object.
        /// </summary>
        public EmotivEntities(string connectionString) : base(connectionString, "EmotivEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new EmotivEntities object.
        /// </summary>
        public EmotivEntities(EntityConnection connection) : base(connection, "EmotivEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<EventType> EventTypes
        {
            get
            {
                if ((_EventTypes == null))
                {
                    _EventTypes = base.CreateObjectSet<EventType>("EventTypes");
                }
                return _EventTypes;
            }
        }
        private ObjectSet<EventType> _EventTypes;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Participant> Participants
        {
            get
            {
                if ((_Participants == null))
                {
                    _Participants = base.CreateObjectSet<Participant>("Participants");
                }
                return _Participants;
            }
        }
        private ObjectSet<Participant> _Participants;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<SavedEvent> SavedEvents
        {
            get
            {
                if ((_SavedEvents == null))
                {
                    _SavedEvents = base.CreateObjectSet<SavedEvent>("SavedEvents");
                }
                return _SavedEvents;
            }
        }
        private ObjectSet<SavedEvent> _SavedEvents;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<SavedEventValue> SavedEventValues
        {
            get
            {
                if ((_SavedEventValues == null))
                {
                    _SavedEventValues = base.CreateObjectSet<SavedEventValue>("SavedEventValues");
                }
                return _SavedEventValues;
            }
        }
        private ObjectSet<SavedEventValue> _SavedEventValues;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the EventTypes EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEventTypes(EventType eventType)
        {
            base.AddObject("EventTypes", eventType);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Participants EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToParticipants(Participant participant)
        {
            base.AddObject("Participants", participant);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the SavedEvents EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSavedEvents(SavedEvent savedEvent)
        {
            base.AddObject("SavedEvents", savedEvent);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the SavedEventValues EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSavedEventValues(SavedEventValue savedEventValue)
        {
            base.AddObject("SavedEventValues", savedEventValue);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EmotivModel", Name="EventType")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class EventType : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new EventType object.
        /// </summary>
        /// <param name="eventTypeID">Initial value of the EventTypeID property.</param>
        public static EventType CreateEventType(global::System.Byte eventTypeID)
        {
            EventType eventType = new EventType();
            eventType.EventTypeID = eventTypeID;
            return eventType;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte EventTypeID
        {
            get
            {
                return _EventTypeID;
            }
            set
            {
                if (_EventTypeID != value)
                {
                    OnEventTypeIDChanging(value);
                    ReportPropertyChanging("EventTypeID");
                    _EventTypeID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("EventTypeID");
                    OnEventTypeIDChanged();
                }
            }
        }
        private global::System.Byte _EventTypeID;
        partial void OnEventTypeIDChanging(global::System.Byte value);
        partial void OnEventTypeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String EventName
        {
            get
            {
                return _EventName;
            }
            set
            {
                OnEventNameChanging(value);
                ReportPropertyChanging("EventName");
                _EventName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("EventName");
                OnEventNameChanged();
            }
        }
        private global::System.String _EventName;
        partial void OnEventNameChanging(global::System.String value);
        partial void OnEventNameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EmotivModel", "fk_EventTypes_pid", "SavedEvent")]
        public EntityCollection<SavedEvent> SavedEvents
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SavedEvent>("EmotivModel.fk_EventTypes_pid", "SavedEvent");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SavedEvent>("EmotivModel.fk_EventTypes_pid", "SavedEvent", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EmotivModel", "fk_EventTypesV_pid", "SavedEventValue")]
        public EntityCollection<SavedEventValue> SavedEventValues
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SavedEventValue>("EmotivModel.fk_EventTypesV_pid", "SavedEventValue");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SavedEventValue>("EmotivModel.fk_EventTypesV_pid", "SavedEventValue", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EmotivModel", Name="Participant")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Participant : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Participant object.
        /// </summary>
        /// <param name="userID">Initial value of the UserID property.</param>
        public static Participant CreateParticipant(global::System.Byte userID)
        {
            Participant participant = new Participant();
            participant.UserID = userID;
            return participant;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                if (_UserID != value)
                {
                    OnUserIDChanging(value);
                    ReportPropertyChanging("UserID");
                    _UserID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserID");
                    OnUserIDChanged();
                }
            }
        }
        private global::System.Byte _UserID;
        partial void OnUserIDChanging(global::System.Byte value);
        partial void OnUserIDChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EmotivModel", "fk_users_pid", "SavedEvent")]
        public EntityCollection<SavedEvent> SavedEvents
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SavedEvent>("EmotivModel.fk_users_pid", "SavedEvent");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SavedEvent>("EmotivModel.fk_users_pid", "SavedEvent", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EmotivModel", "fk_usersV_pid", "SavedEventValue")]
        public EntityCollection<SavedEventValue> SavedEventValues
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SavedEventValue>("EmotivModel.fk_usersV_pid", "SavedEventValue");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SavedEventValue>("EmotivModel.fk_usersV_pid", "SavedEventValue", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EmotivModel", Name="SavedEvent")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class SavedEvent : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new SavedEvent object.
        /// </summary>
        /// <param name="eventTypeID">Initial value of the EventTypeID property.</param>
        /// <param name="userID">Initial value of the UserID property.</param>
        /// <param name="eventTime">Initial value of the EventTime property.</param>
        public static SavedEvent CreateSavedEvent(global::System.Byte eventTypeID, global::System.Byte userID, global::System.DateTime eventTime)
        {
            SavedEvent savedEvent = new SavedEvent();
            savedEvent.EventTypeID = eventTypeID;
            savedEvent.UserID = userID;
            savedEvent.EventTime = eventTime;
            return savedEvent;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte EventTypeID
        {
            get
            {
                return _EventTypeID;
            }
            set
            {
                if (_EventTypeID != value)
                {
                    OnEventTypeIDChanging(value);
                    ReportPropertyChanging("EventTypeID");
                    _EventTypeID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("EventTypeID");
                    OnEventTypeIDChanged();
                }
            }
        }
        private global::System.Byte _EventTypeID;
        partial void OnEventTypeIDChanging(global::System.Byte value);
        partial void OnEventTypeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                if (_UserID != value)
                {
                    OnUserIDChanging(value);
                    ReportPropertyChanging("UserID");
                    _UserID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserID");
                    OnUserIDChanged();
                }
            }
        }
        private global::System.Byte _UserID;
        partial void OnUserIDChanging(global::System.Byte value);
        partial void OnUserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime EventTime
        {
            get
            {
                return _EventTime;
            }
            set
            {
                if (_EventTime != value)
                {
                    OnEventTimeChanging(value);
                    ReportPropertyChanging("EventTime");
                    _EventTime = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("EventTime");
                    OnEventTimeChanged();
                }
            }
        }
        private global::System.DateTime _EventTime;
        partial void OnEventTimeChanging(global::System.DateTime value);
        partial void OnEventTimeChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EmotivModel", "fk_EventTypes_pid", "EventType")]
        public EventType EventType
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<EventType>("EmotivModel.fk_EventTypes_pid", "EventType").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<EventType>("EmotivModel.fk_EventTypes_pid", "EventType").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<EventType> EventTypeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<EventType>("EmotivModel.fk_EventTypes_pid", "EventType");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<EventType>("EmotivModel.fk_EventTypes_pid", "EventType", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EmotivModel", "fk_users_pid", "Participant")]
        public Participant Participant
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Participant>("EmotivModel.fk_users_pid", "Participant").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Participant>("EmotivModel.fk_users_pid", "Participant").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Participant> ParticipantReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Participant>("EmotivModel.fk_users_pid", "Participant");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Participant>("EmotivModel.fk_users_pid", "Participant", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EmotivModel", Name="SavedEventValue")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class SavedEventValue : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new SavedEventValue object.
        /// </summary>
        /// <param name="eventTypeID">Initial value of the EventTypeID property.</param>
        /// <param name="userID">Initial value of the UserID property.</param>
        /// <param name="eventTime">Initial value of the EventTime property.</param>
        public static SavedEventValue CreateSavedEventValue(global::System.Byte eventTypeID, global::System.Byte userID, global::System.DateTime eventTime)
        {
            SavedEventValue savedEventValue = new SavedEventValue();
            savedEventValue.EventTypeID = eventTypeID;
            savedEventValue.UserID = userID;
            savedEventValue.EventTime = eventTime;
            return savedEventValue;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte EventTypeID
        {
            get
            {
                return _EventTypeID;
            }
            set
            {
                if (_EventTypeID != value)
                {
                    OnEventTypeIDChanging(value);
                    ReportPropertyChanging("EventTypeID");
                    _EventTypeID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("EventTypeID");
                    OnEventTypeIDChanged();
                }
            }
        }
        private global::System.Byte _EventTypeID;
        partial void OnEventTypeIDChanging(global::System.Byte value);
        partial void OnEventTypeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                if (_UserID != value)
                {
                    OnUserIDChanging(value);
                    ReportPropertyChanging("UserID");
                    _UserID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserID");
                    OnUserIDChanged();
                }
            }
        }
        private global::System.Byte _UserID;
        partial void OnUserIDChanging(global::System.Byte value);
        partial void OnUserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime EventTime
        {
            get
            {
                return _EventTime;
            }
            set
            {
                if (_EventTime != value)
                {
                    OnEventTimeChanging(value);
                    ReportPropertyChanging("EventTime");
                    _EventTime = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("EventTime");
                    OnEventTimeChanged();
                }
            }
        }
        private global::System.DateTime _EventTime;
        partial void OnEventTimeChanging(global::System.DateTime value);
        partial void OnEventTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Single> Value
        {
            get
            {
                return _Value;
            }
            set
            {
                OnValueChanging(value);
                ReportPropertyChanging("Value");
                _Value = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Value");
                OnValueChanged();
            }
        }
        private Nullable<global::System.Single> _Value;
        partial void OnValueChanging(Nullable<global::System.Single> value);
        partial void OnValueChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EmotivModel", "fk_EventTypesV_pid", "EventType")]
        public EventType EventType
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<EventType>("EmotivModel.fk_EventTypesV_pid", "EventType").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<EventType>("EmotivModel.fk_EventTypesV_pid", "EventType").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<EventType> EventTypeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<EventType>("EmotivModel.fk_EventTypesV_pid", "EventType");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<EventType>("EmotivModel.fk_EventTypesV_pid", "EventType", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EmotivModel", "fk_usersV_pid", "Participant")]
        public Participant Participant
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Participant>("EmotivModel.fk_usersV_pid", "Participant").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Participant>("EmotivModel.fk_usersV_pid", "Participant").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Participant> ParticipantReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Participant>("EmotivModel.fk_usersV_pid", "Participant");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Participant>("EmotivModel.fk_usersV_pid", "Participant", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
