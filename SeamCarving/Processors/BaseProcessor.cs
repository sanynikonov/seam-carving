using System;
using System.Collections.Generic;
using System.Text;

namespace SeamCarving.Processors
{
    public abstract class BaseProcessor : IProcessor
    {
        protected IProcessor _next;

        public abstract void Process(ProcessingContext context);

        public void SetNext(IProcessor processor)
        {
            _next = processor;
        }

        protected void ProcessNextIfNotNull(ProcessingContext context)
        {
            if (_next != null)
            {
                _next.Process(context);
            }
        }
    }
}
