using System;
using System.Collections.Generic;
using System.Text;

namespace SeamCarving.Processors
{
    public class GenericProcessor : BaseProcessor
    {
        private Action<ProcessingContext> _processingAction;

        public GenericProcessor(Action<ProcessingContext> processingAction)
        {
            _processingAction = processingAction;
        }

        public override void Process(ProcessingContext context)
        {
            _processingAction(context);
            ProcessNextIfNotNull(context);
        }
    }
}
