using System;
using System.Globalization;

namespace ExceptionReflector.ILReader
{
    public class ReadableILStringVisitor : ILInstructionVisitor
    {
        protected IILStringCollector collector;
        protected IFormatProvider formatProvider;

        public ReadableILStringVisitor(IILStringCollector collector)
            : this(collector, DefaultFormatProvider.Instance)
        {
        }

        public ReadableILStringVisitor(IILStringCollector collector, IFormatProvider formatProvider)
        {
            this.formatProvider = formatProvider;
            this.collector = collector;
        }

        public override void VisitInlineBrTargetInstruction(InlineBrTargetInstruction inlineBrTargetInstruction)
        {
            collector.Process(inlineBrTargetInstruction, formatProvider.Label(inlineBrTargetInstruction.TargetOffset));
        }

        public override void VisitInlineFieldInstruction(InlineFieldInstruction inlineFieldInstruction)
        {
            string field;
            try
            {
                field = inlineFieldInstruction.Field + "/" + inlineFieldInstruction.Field.DeclaringType;
            }
            catch (Exception ex)
            {
                field = "!" + ex.Message + "!";
            }
            collector.Process(inlineFieldInstruction, field);
        }

        public override void VisitInlineIInstruction(InlineIInstruction inlineIInstruction)
        {
            collector.Process(inlineIInstruction, inlineIInstruction.Int32.ToString(CultureInfo.InvariantCulture));
        }

        public override void VisitInlineI8Instruction(InlineI8Instruction inlineI8Instruction)
        {
            collector.Process(inlineI8Instruction, inlineI8Instruction.Int64.ToString(CultureInfo.InvariantCulture));
        }

        public override void VisitInlineMethodInstruction(InlineMethodInstruction inlineMethodInstruction)
        {
            string method;
            try
            {
                method = inlineMethodInstruction.Method + "/" + inlineMethodInstruction.Method.DeclaringType;
            }
            catch (Exception ex)
            {
                method = "!" + ex.Message + "!";
            }
            collector.Process(inlineMethodInstruction, method);
        }

        public override void VisitInlineNoneInstruction(InlineNoneInstruction inlineNoneInstruction)
        {
            collector.Process(inlineNoneInstruction, string.Empty);
        }

        public override void VisitInlineRInstruction(InlineRInstruction inlineRInstruction)
        {
            collector.Process(inlineRInstruction, inlineRInstruction.Double.ToString(CultureInfo.InvariantCulture));
        }

        public override void VisitInlineSigInstruction(InlineSigInstruction inlineSigInstruction)
        {
            collector.Process(inlineSigInstruction, formatProvider.SigByteArrayToString(inlineSigInstruction.Signature));
        }

        public override void VisitInlineStringInstruction(InlineStringInstruction inlineStringInstruction)
        {
            collector.Process(inlineStringInstruction, formatProvider.EscapedString(inlineStringInstruction.String));
        }

        public override void VisitInlineSwitchInstruction(InlineSwitchInstruction inlineSwitchInstruction)
        {
            collector.Process(inlineSwitchInstruction, formatProvider.MultipleLabels(inlineSwitchInstruction.TargetOffsets));
        }

        public override void VisitInlineTokInstruction(InlineTokInstruction inlineTokInstruction)
        {
            string member;
            try
            {
                member = inlineTokInstruction.Member + "/" + inlineTokInstruction.Member.DeclaringType;
            }
            catch (Exception ex)
            {
                member = "!" + ex.Message + "!";
            }
            collector.Process(inlineTokInstruction, member);
        }

        public override void VisitInlineTypeInstruction(InlineTypeInstruction inlineTypeInstruction)
        {
            string type;
            try
            {
                type = inlineTypeInstruction.Type.Name;
            }
            catch (Exception ex)
            {
                type = "!" + ex.Message + "!";
            }
            collector.Process(inlineTypeInstruction, type);
        }

        public override void VisitInlineVarInstruction(InlineVarInstruction inlineVarInstruction)
        {
            collector.Process(inlineVarInstruction, formatProvider.Argument(inlineVarInstruction.Ordinal));
        }

        public override void VisitShortInlineBrTargetInstruction(ShortInlineBrTargetInstruction shortInlineBrTargetInstruction)
        {
            collector.Process(shortInlineBrTargetInstruction, formatProvider.Label(shortInlineBrTargetInstruction.TargetOffset));
        }

        public override void VisitShortInlineIInstruction(ShortInlineIInstruction shortInlineIInstruction)
        {
            collector.Process(shortInlineIInstruction, shortInlineIInstruction.Byte.ToString(CultureInfo.InvariantCulture));
        }

        public override void VisitShortInlineRInstruction(ShortInlineRInstruction shortInlineRInstruction)
        {
            collector.Process(shortInlineRInstruction, shortInlineRInstruction.Single.ToString(CultureInfo.InvariantCulture));
        }

        public override void VisitShortInlineVarInstruction(ShortInlineVarInstruction shortInlineVarInstruction)
        {
            collector.Process(shortInlineVarInstruction, formatProvider.Argument(shortInlineVarInstruction.Ordinal));
        }
    }
}