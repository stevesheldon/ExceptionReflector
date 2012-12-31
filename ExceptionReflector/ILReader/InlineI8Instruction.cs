using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineI8Instruction : ILInstruction
    {
        private Int64 m_int64;

        public Int64 Int64
        {
            get
            {
                return m_int64;
            }
        }

        internal InlineI8Instruction(Int32 offset, OpCode opCode, Int64 value)
            : base(offset, opCode)
        {
            m_int64 = value;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineI8Instruction(this);
        }
    }
}