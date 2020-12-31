using SeamCarving.Processors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeamCarving.Builder
{
    public interface IProcessorBuilder
    {
        IProcessorBuilder SetProcessor(IProcessor processor);

        IProcessorBuilder Reset();
        IProcessor Build();
    }
}
