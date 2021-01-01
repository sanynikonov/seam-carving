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
            IProcessor pixelPathsProcessor;
            if (vertical)
                pixelPathsProcessor = new PixelPathsProcessor();
            else pixelPathsProcessor = new HorizontalPixelPathsProcessor();

            return builder.SetProcessor(pixelPathsProcessor);
        }

        public static IProcessorBuilder SetShortestPathFinder(this IProcessorBuilder builder, bool vertical)
        {
            IProcessor shortestPathFinder;
            if (vertical)
                shortestPathFinder = new Processors.ShortestPathFinder();
            else shortestPathFinder = new HorizontalShortestPathFinder();

            return builder.SetProcessor(shortestPathFinder);
        }

        public static IProcessorBuilder SetShortestPathRemover(this IProcessorBuilder builder, bool vertical)
        {
            IProcessor shortestPathRemover;
            if (vertical)
                shortestPathRemover = new ShortestPathRemover();
            else shortestPathRemover = new HorizontalShortestPathRemover();

            return builder.SetProcessor(shortestPathRemover);
        }

        public static IProcessorBuilder SetJpegImageSaver(this IProcessorBuilder builder, int width, int height)
        {
            return builder.SetProcessor(new JpegImageSaver(width, height));
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
