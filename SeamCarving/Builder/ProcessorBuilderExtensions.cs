using SeamCarving.Processors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeamCarving.Builder
{
    public static class ProcessorBuilderExtensions
    {
        public static IProcessorBuilder SetPixelEnergyCalculator(this IProcessorBuilder builder)
        {
            return builder.SetProcessor(new PixelEnergyCalculator());
        }

        public static IProcessorBuilder SetPixelPathsProcessor(this IProcessorBuilder builder, bool vertical)
        {
            var pixelPathsProcessor = vertical
                ? new PixelPathsProcessor() as IProcessor
                : new HorizontalPixelPathsProcessor();

            return builder.SetProcessor(pixelPathsProcessor);
        }

        public static IProcessorBuilder SetShortestPathFinder(this IProcessorBuilder builder, bool vertical)
        {
            IProcessor shortestPathFinder = vertical
                ? new ShortestPathFinder() as IProcessor
                : new HorizontalShortestPathFinder();

            return builder.SetProcessor(shortestPathFinder);
        }

        public static IProcessorBuilder SetShortestPathRemover(this IProcessorBuilder builder, bool vertical)
        {
            IProcessor shortestPathRemover = vertical
                ? new ShortestPathRemover() as IProcessor
                : new HorizontalShortestPathRemover();

            return builder.SetProcessor(shortestPathRemover);
        }

        public static IProcessorBuilder SetJpegImageSaver(this IProcessorBuilder builder, string destination, int width, int height)
        {
            return builder.SetProcessor(new JpegImageSaver(destination, width, height));
        }

        public static IProcessorBuilder SetProcessor(this IProcessorBuilder builder, Action<ProcessingContext> processingAction)
        {
            return builder.SetProcessor(new GenericProcessor(processingAction));
        }

        public static IProcessorBuilder SetDefaultVerticalConveyor(this IProcessorBuilder builder)
        {
            return builder
                .SetPixelEnergyCalculator()
                .SetPixelPathsProcessor(true)
                .SetShortestPathFinder(true)
                .SetShortestPathRemover(true);
        }

        public static IProcessorBuilder SetDefaultHorizontalConveyor(this IProcessorBuilder builder)
        {
            return builder
                .SetPixelEnergyCalculator()
                .SetPixelPathsProcessor(false)
                .SetShortestPathFinder(false)
                .SetShortestPathRemover(false);
        }
    }
}
