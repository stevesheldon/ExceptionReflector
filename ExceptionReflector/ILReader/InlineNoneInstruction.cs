using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineNoneInstruction : ILInstruction
    {
        internal InlineNoneInstruction(Int32 offset, OpCode opCode)
            : base(offset, opCode)
        {
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineNoneInstruction(this);
        }
    }
}