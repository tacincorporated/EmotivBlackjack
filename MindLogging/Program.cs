using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emotiv;
using Logger;
using System.Threading;

namespace MindLogging
{
    class Program
    {
        EmoEngine engine;
        public byte user;
        uint EmotivUser = 0;
        static void Main(string[] args)
        {
            Program program = new Program(Convert.ToByte(args[0]));
            Console.WriteLine("Setup worked and the user id is "+ program.user.ToString());
            program.RunLoop();
        }

        public Program(byte userInput)
        {
            user = userInput;
            engine = EmoEngine.Instance;
            if (user == 1)
            {
                engine.RemoteConnect("127.0.0.1", 1726);
            }
            else
            {
                //engine.RemoteConnect("127.0.0.1", 1726);
                engine.Connect();
            }    
            engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(engine_EmoStateUpdated);
            engine.HeadsetGyroRezero(engine.EngineGetNumUser());
        }
        void RunLoop()
        {
            for (; ; )
            {
                engine.ProcessEvents();
                Thread.Sleep(TimeSpan.FromMilliseconds(1));
                try
                {
                    Sender.uploadEmotivRaw(user,DateTime.Now, engine.GetData(this.EmotivUser));
                }
                catch(Exception e)
                {
                    Sender.StoreEvent(user, e.Message);
                }
            }
        }
        static float bool2float(bool input)
        {
            if (input == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
 
        }

        void engine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {

            EmotivUser = e.userId;
            // enable data aquisition for this user.
            engine.DataAcquisitionEnable(e.userId, true);

            // ask for up to 1 second of buffered data
            engine.EE_DataSetBufferSizeInSec(1); 



            EmoState es = e.emoState;
            DateTime now = DateTime.Now;
            //int x,y;
            //engine.HeadsetGetGyroDelta(e.userId, out x, out y);
            
            //values["GyroDeltaX"] = (float)x;
            //values["GyroDeltaY"] = (float)y;
            Dictionary<string, float> values = new Dictionary<string,float>();
            values["AffectivGetExcitementShortTermScore"] = es.AffectivGetExcitementShortTermScore();
            values["AffectivGetExcitementLongTermScore"] = es.AffectivGetExcitementLongTermScore();
            values["AffectivGetEngagementBoredomScore"] = es.AffectivGetEngagementBoredomScore();
            values["AffectivGetMeditationScore"] = es.AffectivGetMeditationScore();
            values["AffectivGetFrustrationScore"] = es.AffectivGetFrustrationScore();
            float leftEye,rightEye;
            es.ExpressivGetEyelidState(out leftEye, out rightEye);
            values["ExpressivGetEyelidStateLeft"] = leftEye;
            values["ExpressivGetEyelidStateRight"] = rightEye;
            es.ExpressivGetEyeLocation(out leftEye, out rightEye);
            values["ExpressivGetEyeLocationLeft"] = leftEye;
            values["ExpressivGetEyeLocationRight"] = rightEye;
            values["ExpressivGetClenchExtent"] = es.ExpressivGetClenchExtent();
            values["ExpressivGetEyebrowExtent"] = es.ExpressivGetEyebrowExtent();
            values["ExpressivGetLowerFaceActionPower"] = es.ExpressivGetLowerFaceActionPower();
            values["ExpressivGetSmileExtent"] = es.ExpressivGetSmileExtent();
            values["ExpressivGetUpperFaceActionPower"] = es.ExpressivGetUpperFaceActionPower();
            values["ExpressivIsBlink"] = bool2float(es.ExpressivIsBlink());
            values["ExpressivIsEyesOpen"] = bool2float(es.ExpressivIsEyesOpen());
            values["ExpressivIsLeftWink"] = bool2float(es.ExpressivIsLeftWink());
            values["ExpressivIsLookingDown"] = bool2float(es.ExpressivIsLookingDown());
            values["ExpressivIsLookingLeft"] = bool2float(es.ExpressivIsLookingLeft());
            values["ExpressivIsLookingRight"] = bool2float(es.ExpressivIsLookingRight());
            values["ExpressivIsLookingUp"] = bool2float(es.ExpressivIsLookingUp());
            values["ExpressivIsRightWink"] = bool2float(es.ExpressivIsRightWink());

            Sender.uploadEmotivEvent(user, now, values);
        }
    }
}