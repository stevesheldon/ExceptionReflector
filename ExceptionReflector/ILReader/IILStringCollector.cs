namespace ExceptionReflector.ILReader
{
    public interface IILStringCollector
    {
        void Process(ILInstruction ilInstruction, string operandString);
    }
}