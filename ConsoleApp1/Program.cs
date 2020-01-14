using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech; 
using System.Speech.Synthesis;
using System.Xml;
using System.Threading;

using System.Speech.Recognition;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer talk = new SpeechSynthesizer();

            RecordSound.startrecording();
            talk.Speak("start the recording for future performance analysis");

            XmlDocument doc = new XmlDocument();
            doc.Load("Questions.xml");




            foreach (XmlNode row in doc.SelectNodes("/Questions/Topic"))
            {
                var questions = row.SelectNodes("question");
                foreach (XmlNode que in questions)
                {
                    string attrque = que.Attributes[0].Value;
                    int responsetime = int.Parse(que.Attributes[1].Value);
                    talk.Speak(attrque);
                    responsetime = responsetime * 60000;
                    Thread.Sleep(responsetime);
                }
            }
            RecordSound.stoprecording();





        }

    
    }
}
