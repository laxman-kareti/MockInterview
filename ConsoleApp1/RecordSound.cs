using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public static class RecordSound
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        public static void startrecording()
        {
            try
            {
                record("open new Type waveaudio Alias recsound", "", 0, 0);
                record("record recsound", "", 0, 0);
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public static void stoprecording()
        {
            StringBuilder saverecordcmd = new StringBuilder();
            saverecordcmd.Append("save recsound ");
            saverecordcmd.Append(@"d:\recordings\" + DateTime.Now.ToString("dd_MMM_yyyy_HH_mm_ss") + ".wav");

            
             

            try
            {
                record(saverecordcmd.ToString(), "", 0, 0);
                record("close recsound", "", 0, 0);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        


    }
}
