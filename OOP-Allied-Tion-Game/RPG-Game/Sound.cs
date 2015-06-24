﻿namespace RPG
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Sound
    {
        [DllImport("winmm.dll")]

        static extern int mciSendString(string mciCommand, StringBuilder buffer, int bufferSize, IntPtr callback);
        string fileName;
        private string Pcommand;

        public void Send(string mciCommand)
        {
            mciSendString(mciCommand, null, 0, IntPtr.Zero);
        }

        public Sound(string fileLocation)
        {
            fileName = fileLocation;
            Send("open " + fileName);
        }

        public void Play(bool loop)
        {
            Pcommand = "play " + fileName;
            if (loop)
                Pcommand += " REPEAT";
            Send(Pcommand);
        }
    }
}
