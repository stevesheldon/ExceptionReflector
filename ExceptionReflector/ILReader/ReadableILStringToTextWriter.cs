using System.IO;

namespace ExceptionReflector.ILReader
{
    public class ReadableILStringToTextWriter : IILStringCollector
    {
        protected TextWriter writer;

        public ReadableILStringToTextWriter(TextWriter writer)
        {
            this.writer = writer;
        }

        #region IILStringCollector Members

        public virtual void Process(ILInstruction ilInstruction, string operandString)
        {
            writer.WriteLine("IL_{0:x4}: {1,-10} {2}",
                             ilInstruction.Offset,
                             ilInstruction.OpCode.Name,
                             operandString);
        }

        #endregion
    }
}