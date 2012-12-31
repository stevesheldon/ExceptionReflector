using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineTokInstruction : ILInstruction
    {
        private MemberInfo m_member;
        private ITokenResolver m_resolver;
        private Int32 m_token;

        public MemberInfo Member
        {
            get
            {
                if (m_member == null)
                {
                    m_member = m_resolver.AsMember(Token);
                }
                return m_member;
            }
        }

        public Int32 Token
        {
            get
            {
                return m_token;
            }
        }

        internal InlineTokInstruction(Int32 offset, OpCode opCode, Int32 token, ITokenResolver resolver)
            : base(offset, opCode)
        {
            m_resolver = resolver;
            m_token = token;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineTokInstruction(this);
        }
    }
}