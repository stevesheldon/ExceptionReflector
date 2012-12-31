using System;
using System.Reflection;

namespace ExceptionReflector.ILReader
{
    public class ModuleScopeTokenResolver : ITokenResolver
    {
        private Type[] m_methodContext;
        private Module m_module;
        private Type[] m_typeContext;

        public ModuleScopeTokenResolver(MethodBase method)
        {
            m_module = method.Module;
            m_methodContext = (method is ConstructorInfo) ? null : method.GetGenericArguments();
            m_typeContext = (method.DeclaringType == null) ? null : method.DeclaringType.GetGenericArguments();
        }

        #region ITokenResolver Members

        public MethodBase AsMethod(int token)
        {
            return m_module.ResolveMethod(token, m_typeContext, m_methodContext);
        }

        public FieldInfo AsField(int token)
        {
            return m_module.ResolveField(token, m_typeContext, m_methodContext);
        }

        public Type AsType(int token)
        {
            return m_module.ResolveType(token, m_typeContext, m_methodContext);
        }

        public MemberInfo AsMember(int token)
        {
            return m_module.ResolveMember(token, m_typeContext, m_methodContext);
        }

        public string AsString(int token)
        {
            return m_module.ResolveString(token);
        }

        public byte[] AsSignature(int token)
        {
            return m_module.ResolveSignature(token);
        }

        #endregion
    }
}