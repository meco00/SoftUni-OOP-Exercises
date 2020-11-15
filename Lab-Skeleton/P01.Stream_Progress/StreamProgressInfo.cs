using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo:ICalculatable
    {
        

        // If we want to stream a music file, we can't
        public StreamProgressInfo(int length,int bytesSent)
        {
           
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }

        public int CalculateCurrentPercent()
        {
            return (this.BytesSent * 100) / this.Length;
        }
    }
}
