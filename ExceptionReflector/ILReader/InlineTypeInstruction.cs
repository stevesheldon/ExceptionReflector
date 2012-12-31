using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineTypeInstruction : ILInstruction
    {
        private ITokenResolver m_resolver;
        private Int32 m_token;
        private Type m_type;

        public Type Type
        {
            get
            {
                if (m_type == null)
                {
                    m_type = m_resolver.AsType(m_token);
                }
                return m_type;
            }
        }

        public Int32 Token
        {
            get
            {
                return m_token;
            }
        }

        internal InlineTypeInstruction(Int32 offset, OpCode opCode, Int32 token, ITokenResolver resolver)
            : base(offset, opCode)
        {
            m_resolver = resolver;
            m_token = token;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineTypeInstruction(this);
        }
    }
}