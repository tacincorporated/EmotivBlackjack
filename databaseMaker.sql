CREATE TABLE Participant
(
	UserID tinyint IDENTITY(1,1) CONSTRAINT pk_users_pid Primary key
);
GO
CREATE TABLE EventType
(
	EventTypeID tinyint IDENTITY(1,1) CONSTRAINT pk_EventTypes_pid Primary key,
	EventName varchar(50) UNIQUE
);
GO
CREATE Table SavedEvent
(
	EventTypeID tinyint CONSTRAINT fk_EventTypes_pid FOREIGN KEY REFERENCES EventType(EventTypeID),
	UserID tinyint CONSTRAINT fk_users_pid FOREIGN KEY REFERENCES Participant(UserID),
	EventTime datetime,
    Primary key (EventTypeID, UserID, EventTime)
); 
GO
CREATE Table SavedEventValue
(
	EventTypeID tinyint CONSTRAINT fk_EventTypesV_pid FOREIGN KEY REFERENCES EventType(EventTypeID),
	UserID tinyint CONSTRAINT fk_usersV_pid FOREIGN KEY REFERENCES Participant(UserID),
	EventTime datetime,
	Value real,
	Primary key (EventTypeID, UserID, EventTime)
); 