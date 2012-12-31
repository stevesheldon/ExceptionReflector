using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class ShortInlineBrTargetInstruction : ILInstruction
    {
        private SByte m_delta;

        public SByte Delta
        {
            get
            {
                return m_delta;
            }
        }

        public Int32 TargetOffset
        {
            get
            {
                return m_offset + m_delta + 1 + 1;
            }
        }

        internal ShortInlineBrTargetInstruction(Int32 offset, OpCode opCode, SByte delta)
            : base(offset, opCode)
        {
            m_delta = delta;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitShortInlineBrTargetInstruction(this);
        }
    }
}