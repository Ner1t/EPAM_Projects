using System;
using System.IO;
using System.Text;

namespace _08_FileWorker
{
    class FileWorker : IDisposable
    {     
        private bool disposed = false;
        public static string Path { get; private set; }
        public static int Length { get; private set; }

        static FileStream stream = null;
        static StreamWriter writer = null;
        static StreamReader reader = null;

        private FileWorker(string path)
        {
            Path = path;
            InitializeStreams();
        }
        private FileWorker(string path, int sequenceLength)
        {
            string s = new(' ', sequenceLength);
            Path = path;
            Length = sequenceLength;

            InitializeStreams();

            writer.Write(s);

            writer.Flush();
            stream.Position = 0;
        }

        public char this[int index]
        {
            get
            {
                if (stream == null)
                {
                    throw new EndOfStreamException("This stream is closed!");
                }

                if (index >= Length)
                {
                    throw new IndexOutOfRangeException("Failed to read character!");
                }

                stream.Position = index;
                return (char)reader.Read();
            }
            set
            {
                if (stream == null)
                {
                    throw new EndOfStreamException("This stream is closed!");
                }
                if (index >= Length)
                {
                    throw new IndexOutOfRangeException("Failed to read character!");
                }

                stream.Position = index;

                writer.Write(value);
                writer.Flush();
            }
        }

        private void InitializeStreams()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            stream = new FileStream(Path, FileMode.OpenOrCreate);
            writer = new StreamWriter(stream, Encoding.GetEncoding(1252));
            reader = new StreamReader(stream, Encoding.GetEncoding(1252));
        }

        public static FileWorker Create(string path, int sequenceLength)
        {
            FileWorker result = new(path, sequenceLength);
            return result;
        }

        public static FileWorker Read()
        {
            FileWorker result = new(Path);
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                stream.Dispose();
            }

            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~FileWorker()
        {
            Dispose(false);
        }
    }
}

