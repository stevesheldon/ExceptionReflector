namespace ExceptionReflector.ILReader
{
    public class RawILStringVisitor : ReadableILStringVisitor
    {
        public RawILStringVisitor(IILStringCollector collector)
            : this(collector, DefaultFormatProvider.Instance)
        {
        }

        public RawILStringVisitor(IILStringCollector collector, IFormatProvider formatProvider)
            : base(collector, formatProvider)
        {
        }

        public override void VisitInlineBrTargetInstruction(InlineBrTargetInstruction inlineBrTargetInstruction)
        {
            collector.Process(inlineBrTargetInstruction, formatProvider.Int32ToHex(inlineBrTargetInstruction.Delta));
        }

        public override void VisitInlineFieldInstruction(InlineFieldInstruction inlineFieldInstruction)
        {
            collector.Process(inlineFieldInstruction, formatProvider.Int32ToHex(inlineFieldInstruction.Token));
        }

        public override void VisitInlineMethodInstruction(InlineMethodInstruction inlineMethodInstruction)
        {
            collector.Process(inlineMethodInstruction, formatProvider.Int32ToHex(inlineMethodInstruction.Token));
        }

        public override void VisitInlineSigInstruction(InlineSigInstruction inlineSigInstruction)
        {
            collector.Process(inlineSigInstruction, formatProvider.Int32ToHex(inlineSigInstruction.Token));
        }

        public override void VisitInlineStringInstruction(InlineStringInstruction inlineStringInstruction)
        {
            collector.Process(inlineStringInstruction, formatProvider.Int32ToHex(inlineStringInstruction.Token));
        }

        public override void VisitInlineSwitchInstruction(InlineSwitchInstruction inlineSwitchInstruction)
        {
            collector.Process(inlineSwitchInstruction, "...");
        }

        public override void VisitInlineTokInstruction(InlineTokInstruction inlineTokInstruction)
        {
            collector.Process(inlineTokInstruction, formatProvider.Int32ToHex(inlineTokInstruction.Token));
        }

        public override void VisitInlineTypeInstruction(InlineTypeInstruction inlineTypeInstruction)
        {
            collector.Process(inlineTypeInstruction, formatProvider.Int32ToHex(inlineTypeInstruction.Token));
        }

        public override void VisitInlineVarInstruction(InlineVarInstruction inlineVarInstruction)
        {
            collector.Process(inlineVarInstruction, formatProvider.Int16ToHex(inlineVarInstruction.Ordinal));
        }

        public override void VisitShortInlineBrTargetInstruction(ShortInlineBrTargetInstruction shortInlineBrTargetInstruction)
        {
            collector.Process(shortInlineBrTargetInstruction, formatProvider.Int8ToHex(shortInlineBrTargetInstruction.Delta));
        }

        public override void VisitShortInlineVarInstruction(ShortInlineVarInstruction shortInlineVarInstruction)
        {
            collector.Process(shortInlineVarInstruction, formatProvider.Int8ToHex(shortInlineVarInstruction.Ordinal));
        }
    }
}