﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace PredikcijaCijeneNekretnine_KonzolnaAplikacija
{
    public partial class PredikcijaCijeneNekretnine
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(@"usecode", @"usecode")      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"bathrooms", @"bathrooms"),new InputOutputColumnPair(@"bedrooms", @"bedrooms"),new InputOutputColumnPair(@"finishedsqft", @"finishedsqft"),new InputOutputColumnPair(@"totalrooms", @"totalrooms")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"usecode",@"bathrooms",@"bedrooms",@"finishedsqft",@"totalrooms"}))      
                                    .Append(mlContext.Regression.Trainers.FastForest(new FastForestRegressionTrainer.Options(){NumberOfTrees=4,FeatureFraction=0.417322301158954F,LabelColumnName=@"lastsoldprice",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
}
