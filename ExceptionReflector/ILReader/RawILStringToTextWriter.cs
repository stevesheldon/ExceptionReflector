using System.IO;

namespace ExceptionReflector.ILReader
{
    public class RawILStringToTextWriter : ReadableILStringToTextWriter
    {
        public RawILStringToTextWriter(TextWriter writer)
            : base(writer)
        {
        }

        public override void Process(ILInstruction ilInstruction, string operandString)
        {
            writer.WriteLine("IL_{0:x4}: {1,-4}| {2, -8}",
                             ilInstruction.Offset,
                             ilInstruction.OpCode.Value.ToString("x2"),
                             operandString);
        }
    }
}