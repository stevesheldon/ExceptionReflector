using System;
using System.Reflection;

namespace ExceptionReflector.ILReader
{
    public class MethodBaseILProvider : IILProvider
    {
        private byte[] m_byteArray;
        private MethodBase m_method;

        public MethodBaseILProvider(MethodBase method)
        {
            m_method = method;
        }

        #region IILProvider Members

        public byte[] GetByteArray()
        {
            if (m_byteArray == null)
            {
                MethodBody methodBody = m_method.GetMethodBody();
                m_byteArray = (methodBody == null) ? new Byte[0] : methodBody.GetILAsByteArray();
            }
            return m_byteArray;
        }

        #endregion
    }
}