using System;
using System.Collections.Generic;
using System.Text;

namespace SeamCarving.Processors
{
    public interface IProcessor
    {
        void SetNext(IProcessor processor);
        void Process(ProcessingContext context);
    }
}
