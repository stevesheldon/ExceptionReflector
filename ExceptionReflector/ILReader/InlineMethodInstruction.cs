using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineMethodInstruction : ILInstruction
    {
        private MethodBase m_method;
        private ITokenResolver m_resolver;
        private Int32 m_token;

        public MethodBase Method
        {
            get
            {
                if (m_method == null)
                {
                    m_method = m_resolver.AsMethod(m_token);
                }
                return m_method;
            }
        }

        public Int32 Token
        {
            get
            {
                return m_token;
            }
        }

        internal InlineMethodInstruction(Int32 offset, OpCode opCode, Int32 token, ITokenResolver resolver)
            : base(offset, opCode)
        {
            m_resolver = resolver;
            m_token = token;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineMethodInstruction(this);
        }
    }
}