using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineFieldInstruction : ILInstruction
    {
        private FieldInfo m_field;
        private ITokenResolver m_resolver;
        private Int32 m_token;

        public FieldInfo Field
        {
            get
            {
                if (m_field == null)
                {
                    m_field = m_resolver.AsField(m_token);
                }
                return m_field;
            }
        }

        public Int32 Token
        {
            get
            {
                return m_token;
            }
        }

        internal InlineFieldInstruction(ITokenResolver resolver, Int32 offset, OpCode opCode, Int32 token)
            : base(offset, opCode)
        {
            m_resolver = resolver;
            m_token = token;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineFieldInstruction(this);
        }
    }
}