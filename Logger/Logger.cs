using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class Sender
    {
        public static void StoreEvent(byte User, string eventType)
        {
            using (EmotivEntities db = new EmotivEntities())
            {
                db.SavedEvents.AddObject(
                    new SavedEvent 
                    {
                        UserID = User,
                        EventTypeID = getEventType(db, eventType),
                        EventTime = DateTime.Now
                    });
                db.SaveChanges();
            }
        }
        public static void StoreValue(byte User, string eventType, float? value)
        {
            using (EmotivEntities db = new EmotivEntities())
            {
                db.SavedEventValues.AddObject(
                    new SavedEventValue
                    {
                        UserID = User,
                        EventTypeID = getEventType(db, eventType),
                        EventTime = DateTime.Now,
                        Value = value 
                    });
                db.SaveChanges();
            } 
        }
        public static byte getEventType(EmotivEntities db, string eventType)
        {
            if (!db.EventTypes.Any(e => e.EventName == eventType))
            {
                db.EventTypes.AddObject(new EventType { EventName = eventType });
                db.SaveChanges();
            }
            return db.EventTypes.First(e=>e.EventName == eventType).EventTypeID;
        }
        public static byte GetUserID()
        {
            using (EmotivEntities db = new EmotivEntities())
            {
                db.Participants.AddObject(new Participant());
                db.SaveChanges();
                return db.Participants.Max(p => p.UserID);
            } 

        }
        public static void uploadEmotivRaw(byte User, DateTime time, Dictionary<Emotiv.EdkDll.EE_DataChannel_t, double[]> input)
        {
            using (EmotivEntities db = new EmotivEntities())
            {

                foreach (var keyvalue in input)
                {
                    foreach (double value in keyvalue.Value)
                    {
                        db.SavedEventValues.AddObject(
                            new SavedEventValue
                            {
                                UserID = User,
                                EventTypeID = getEventType(db, keyvalue.Key.ToString()),
                                EventTime = time,
                                Value = (float)value
                            });
                    }
                }
                db.SaveChanges();
            } 
        }
        public static void uploadEmotivEvent(byte User,DateTime time,Dictionary<string, float>  values)
        {
            using (EmotivEntities db = new EmotivEntities())
            {

                foreach (var keyvalue in values)
                {
                        db.SavedEventValues.AddObject(
                            new SavedEventValue
                            {
                                UserID = User,
                                EventTypeID = getEventType(db, keyvalue.Key),
                                EventTime = time,
                                Value = keyvalue.Value
                            });
                }
                db.SaveChanges();
            } 
        }
    }
}
