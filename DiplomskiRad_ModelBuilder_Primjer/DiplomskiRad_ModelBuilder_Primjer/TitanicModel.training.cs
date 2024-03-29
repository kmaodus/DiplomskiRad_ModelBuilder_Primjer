﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace DiplomskiRad_ModelBuilder_Primjer
{
    public partial class TitanicModel
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
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new []{new InputOutputColumnPair(@"Sex", @"Sex"),new InputOutputColumnPair(@"Embarked", @"Embarked")})      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"PassengerId", @"PassengerId"),new InputOutputColumnPair(@"Pclass", @"Pclass"),new InputOutputColumnPair(@"Age", @"Age"),new InputOutputColumnPair(@"SibSp", @"SibSp"),new InputOutputColumnPair(@"Parch", @"Parch"),new InputOutputColumnPair(@"Fare", @"Fare")}))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"Name", @"Name"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"Ticket", @"Ticket"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"Cabin", @"Cabin"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Sex",@"Embarked",@"PassengerId",@"Pclass",@"Age",@"SibSp",@"Parch",@"Fare",@"Name",@"Ticket",@"Cabin"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(@"Survived", @"Survived"))      
                                    .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression(l1Regularization:0.170859100144544F,l2Regularization:0.427633330029212F,labelColumnName:@"Survived",featureColumnName:@"Features"), labelColumnName: @"Survived"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(@"PredictedLabel", @"PredictedLabel"));

            return pipeline;
        }
    }
}
