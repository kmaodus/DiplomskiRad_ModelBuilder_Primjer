﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace PredikcijaKvaraStroja_KonzolnaAplikacija
{
    public partial class PredikcijaKvaraStroja
    {
        /// <summary>
        /// model input class for PredikcijaKvaraStroja.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"UDI")]
            public float UDI { get; set; }

            [ColumnName(@"Product ID")]
            public string Product_ID { get; set; }

            [ColumnName(@"Type")]
            public string Type { get; set; }

            [ColumnName(@"Air temperature")]
            public float Air_temperature { get; set; }

            [ColumnName(@"Process temperature")]
            public float Process_temperature { get; set; }

            [ColumnName(@"Rotational speed")]
            public float Rotational_speed { get; set; }

            [ColumnName(@"Torque")]
            public float Torque { get; set; }

            [ColumnName(@"Tool wear")]
            public float Tool_wear { get; set; }

            [ColumnName(@"Machine failure")]
            public float Machine_failure { get; set; }

            [ColumnName(@"TWF")]
            public float TWF { get; set; }

            [ColumnName(@"HDF")]
            public float HDF { get; set; }

            [ColumnName(@"PWF")]
            public float PWF { get; set; }

            [ColumnName(@"OSF")]
            public float OSF { get; set; }

            [ColumnName(@"RNF")]
            public float RNF { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for PredikcijaKvaraStroja.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName("PredictedLabel")]
            public float Prediction { get; set; }

            public float[] Score { get; set; }
        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("PredikcijaKvaraStroja.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
