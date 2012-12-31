using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineStringInstruction : ILInstruction
    {
        private ITokenResolver m_resolver;
        private String m_string;
        private Int32 m_token;

        public String String
        {
            get
            {
                if (m_string == null)
                {
                    m_string = m_resolver.AsString(Token);
                }
                return m_string;
            }
        }

        public Int32 Token
        {
            get
            {
                return m_token;
            }
        }

        internal InlineStringInstruction(Int32 offset, OpCode opCode, Int32 token, ITokenResolver resolver)
            : base(offset, opCode)
        {
            m_resolver = resolver;
            m_token = token;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineStringInstruction(this);
        }
    }
}