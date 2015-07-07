using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Terraria.Net.Sockets
{
    public struct BufferSegment
    {
        public long From { get; private set; }
        public long To { get; private set; }
        long Count { get { return To - From; } }

        public BufferSegment(long @from, long to)
        {
            this.From = @from;
            this.To = to;
        }
    }

    public class SendQueue : IDisposable
    {
        protected const int kSendQueueInitialBufferSize = 262144;

        protected byte[] sendBuffer;
        protected List<ArraySegment<byte>> bufferSegments;
        protected readonly object syncLock = new object();
        protected Thread sendThread;

        public event EventHandler WriteFailed;
        public event EventHandler BufferGrow;

        public SendQueue()
        {
            sendBuffer = new byte[kSendQueueInitialBufferSize];
        }

        protected void Grow(int sizeDelta)
        {
            byte[] buffer;

            try
            {
                Array.Resize<byte>(ref sendBuffer, sizeDelta);
            }
            catch (OutOfMemoryException oom)
            {
                Console.WriteLine("Grow failed: Out of memory asking for {0} bytes", sizeDelta);
            }

        }

        internal void __segment_release_internal(ArraySegment<byte> segment)
        {
            lock (syncLock)
            {
                bufferSegments.Remove(segment);
            }
        }

        internal ArraySegment<byte> __segment_lock_internal(int offset, int size)
        {
            ArraySegment<byte> newSegment;
            lock (syncLock)
            {
                bufferSegments.Add((newSegment = new ArraySegment<byte>(sendBuffer, 0, size)));
            }

            return newSegment;
        }

        protected ArraySegment<byte> LockSegment(int size)
        {
            lock (syncLock)
            {
                /*
                 * If there are no segments in the buffer, it is completely
                 * free.
                 */
                if (bufferSegments.Count == 0)
                {
                    return __segment_lock_internal(0, size);
                }

                for (int i = 0; i < bufferSegments.Count; i++)
                {
                    ArraySegment<byte>? prevSegment = bufferSegments.ElementAtOrDefault(i - 1);
                    ArraySegment<byte> thisSegment = bufferSegments[i];
                    ArraySegment<byte>? nextSegment = bufferSegments.ElementAtOrDefault(i + 2);

                    /*
                     * If this is the first segment and the distance between
                     * here and the start of the array is big enough to fit the
                     * segment then fit it at position 0.
                     */
                    if (i == 0 && thisSegment.Offset < size)
                    {
                        return __segment_lock_internal(0, size);
                    }

                    //new segment can fit before this segment
                    if (prevSegment.HasValue && (thisSegment.Offset - (prevSegment.Value.Offset - prevSegment.Value.Count)) > size)
                    {
                        return __segment_lock_internal(prevSegment.Value.Offset + prevSegment.Value.Count, size);
                    }

                    //new segment can fit after this segment
                    if (nextSegment.HasValue && nextSegment.Value.Offset - (thisSegment.Offset + thisSegment.Count) > size)
                    {
                        return __segment_lock_internal(thisSegment.Offset + thisSegment.Count, size);
                    }

                    //The buffer must get bigger to accommodate
                    //TODO
                }
            }
        }

        protected void ReleaseSegment(ArraySegment<byte> segment)
        {

        }

        protected BinaryWriter ReserveSegment(short size)
        {
            return new System.IO.BinaryWriter(new System.IO.MemoryStream());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }
    }
}
