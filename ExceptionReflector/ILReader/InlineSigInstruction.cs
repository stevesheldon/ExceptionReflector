using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineSigInstruction : ILInstruction
    {
        private ITokenResolver m_resolver;
        private byte[] m_signature;
        private Int32 m_token;

        public byte[] Signature
        {
            get
            {
                if (m_signature == null)
                {
                    m_signature = m_resolver.AsSignature(m_token);
                }
                return m_signature;
            }
        }

        public Int32 Token
        {
            get
            {
                return m_token;
            }
        }

        internal InlineSigInstruction(Int32 offset, OpCode opCode, Int32 token, ITokenResolver resolver)
            : base(offset, opCode)
        {
            m_resolver = resolver;
            m_token = token;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineSigInstruction(this);
        }
    }
}