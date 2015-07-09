using System;
using System.IO;

namespace Terraria.Net.Sockets
{
    public class SegmentWriter : System.IO.BinaryWriter
    {
        protected ArraySegment<byte> segment;
        protected SendQueue queue;

        protected static MemoryStream MakeStream(ArraySegment<byte> segment, bool readWrite = true)
        {
            return new MemoryStream(segment.Array, segment.Offset, segment.Count, readWrite);
        }

        public SegmentWriter(SendQueue queue, ArraySegment<byte> segment)
            : base(MakeStream(segment), System.Text.Encoding.UTF8)
        {
            this.segment = segment;
            this.queue = queue;
        }

        
        public void Enqueue()
        {
            queue.Enqueue(segment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            /*
             * Prevent segment leak.  The segment MUST be unlocked
             * completely regardless of GC or dispose.
             */
            queue.__segment_release_internal(segment);

            base.Dispose(disposing);
        }
    }
}
