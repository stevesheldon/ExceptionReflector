using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class ShortInlineVarInstruction : ILInstruction
    {
        private Byte m_ordinal;

        public Byte Ordinal
        {
            get
            {
                return m_ordinal;
            }
        }

        internal ShortInlineVarInstruction(Int32 offset, OpCode opCode, Byte ordinal)
            : base(offset, opCode)
        {
            m_ordinal = ordinal;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitShortInlineVarInstruction(this);
        }
    }
}