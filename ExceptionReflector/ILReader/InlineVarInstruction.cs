using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineVarInstruction : ILInstruction
    {
        private UInt16 m_ordinal;

        public UInt16 Ordinal
        {
            get
            {
                return m_ordinal;
            }
        }

        internal InlineVarInstruction(Int32 offset, OpCode opCode, UInt16 ordinal)
            : base(offset, opCode)
        {
            m_ordinal = ordinal;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineVarInstruction(this);
        }
    }
}