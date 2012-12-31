using System;
using System.Reflection.Emit;

namespace ExceptionReflector.ILReader
{
    public class InlineSwitchInstruction : ILInstruction
    {
        private Int32[] m_deltas;
        private Int32[] m_targetOffsets;

        public Int32[] Deltas
        {
            get
            {
                return (Int32[]) m_deltas.Clone();
            }
        }

        public Int32[] TargetOffsets
        {
            get
            {
                if (m_targetOffsets == null)
                {
                    int cases = m_deltas.Length;
                    int itself = 1 + 4 + 4 * cases;
                    m_targetOffsets = new Int32[cases];
                    for (Int32 i = 0; i < cases; i++)
                    {
                        m_targetOffsets[i] = m_offset + m_deltas[i] + itself;
                    }
                }
                return m_targetOffsets;
            }
        }

        internal InlineSwitchInstruction(Int32 offset, OpCode opCode, Int32[] deltas)
            : base(offset, opCode)
        {
            m_deltas = deltas;
        }

        public override void Accept(ILInstructionVisitor vistor)
        {
            vistor.VisitInlineSwitchInstruction(this);
        }
    }
}