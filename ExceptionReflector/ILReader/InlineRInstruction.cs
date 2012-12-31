using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineRInstruction : ILInstruction
    {
        private Double m_value;

        public Double Double
        {
            get
            {
                return m_value;
            }
        }

        internal InlineRInstruction(Int32 offset, OpCode opCode, Double value)
            : base(offset, opCode)
        {
            m_value = value;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineRInstruction(this);
        }
    }
}