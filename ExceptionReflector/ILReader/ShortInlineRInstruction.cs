using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class ShortInlineRInstruction : ILInstruction
    {
        private Single m_value;

        public Single Single
        {
            get
            {
                return m_value;
            }
        }

        internal ShortInlineRInstruction(Int32 offset, OpCode opCode, Single value)
            : base(offset, opCode)
        {
            m_value = value;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitShortInlineRInstruction(this);
        }
    }
}