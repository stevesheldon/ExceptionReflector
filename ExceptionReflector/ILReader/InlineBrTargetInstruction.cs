using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineBrTargetInstruction : ILInstruction
    {
        private Int32 m_delta;

        public Int32 Delta
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
                return m_offset + m_delta + 1 + 4;
            }
        }

        internal InlineBrTargetInstruction(Int32 offset, OpCode opCode, Int32 delta)
            : base(offset, opCode)
        {
            m_delta = delta;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineBrTargetInstruction(this);
        }
    }
}