using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineIInstruction : ILInstruction
    {
        private Int32 m_int32;

        public Int32 Int32
        {
            get
            {
                return m_int32;
            }
        }

        internal InlineIInstruction(Int32 offset, OpCode opCode, Int32 value)
            : base(offset, opCode)
        {
            m_int32 = value;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineIInstruction(this);
        }
    }
}