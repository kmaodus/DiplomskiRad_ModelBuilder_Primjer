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

namespace ModelBuilder_primjer
{
    public partial class PredikcijaKvaraStroja
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
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(@"Type", @"Type")      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Air temperature", @"Air temperature"),new InputOutputColumnPair(@"Process temperature", @"Process temperature"),new InputOutputColumnPair(@"Rotational speed", @"Rotational speed"),new InputOutputColumnPair(@"Torque", @"Torque"),new InputOutputColumnPair(@"Tool wear", @"Tool wear")}))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"Product ID", @"Product ID"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Type",@"Air temperature",@"Process temperature",@"Rotational speed",@"Torque",@"Tool wear",@"Product ID"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(@"Machine failure", @"Machine failure"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options(){NumberOfLeaves=5,MinimumExampleCountPerLeaf=30,NumberOfTrees=4,MaximumBinCountPerFeature=158,LearningRate=0.0283305433978588F,FeatureFraction=1F,LabelColumnName=@"Machine failure",FeatureColumnName=@"Features"}), labelColumnName: @"Machine failure"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(@"PredictedLabel", @"PredictedLabel"));

            return pipeline;
        }
    }
}
