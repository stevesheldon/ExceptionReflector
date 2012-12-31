using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class ShortInlineIInstruction : ILInstruction
    {
        private Byte m_int8;

        public Byte Byte
        {
            get
            {
                return m_int8;
            }
        }

        internal ShortInlineIInstruction(Int32 offset, OpCode opCode, Byte value)
            : base(offset, opCode)
        {
            m_int8 = value;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitShortInlineIInstruction(this);
        }
    }
}