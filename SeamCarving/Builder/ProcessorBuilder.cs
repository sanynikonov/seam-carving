using SeamCarving.Processors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeamCarving.Builder
{
    public class ProcessorBuilder : IProcessorBuilder
    {
        private IProcessor _firstProcessor;
        private IProcessor _lastProcessor;

        public IProcessor Build()
        {
            return _lastProcessor;
        }

        public IProcessorBuilder Reset()
        {
            _firstProcessor = null;
            return this;
        }

        public IProcessorBuilder SetProcessor(IProcessor processor)
        {
            if (_firstProcessor == null)
            {
                _firstProcessor = processor;
                _lastProcessor = _firstProcessor;
            }
            else
            {
                _lastProcessor.SetNext(processor);
                _lastProcessor = processor;
            }

            return this;
        }
    }
}
