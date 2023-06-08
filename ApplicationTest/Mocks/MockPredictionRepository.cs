using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Match = Domain.Entities.Match;

namespace ApplicationTest.Mocks
{
    public class MockPredictionRepository : IPredictionRepository
    {
        public List<Prediction> Predictions { get; set; }
        public MockPredictionRepository(List<Prediction> predictions) 
        { 
            Predictions = predictions;
        }
        public void InsertIntoPrediction(Prediction prediction)
        {
            Predictions.Add(prediction);
        }
        public void UpdateAccuracy(Prediction prediction) 
        {
            prediction.Guessed = true;
        }
        public void DeleteIntoPrediction(Prediction prediction)
        {
            Predictions.Remove(prediction);
        }
        public List<Prediction>? GetPredictions()
        {
            return Predictions;
        }
        public Prediction? GetPredictionById(int id)
        {
            foreach (Prediction prediction in Predictions)
            {
                if (prediction.GetId() == id)
                {
                    return prediction;
                }
            }
            return null;
        }
        public List<Prediction>? GetMatchPredictions(Match match)
        {
            List<Prediction>? MatchPredictions = new List<Prediction>();
            foreach (Prediction prediction in Predictions)
            {
                if (prediction.MatchId == match.GetId())
                {
                    MatchPredictions.Add(prediction);
                }
            }
            return MatchPredictions;
        }
        public List<Prediction>? GetSportPredictions(Sport sport)
        {
            List<Prediction>? SportPredictions = new List<Prediction>();
            foreach (Prediction prediction in Predictions)
            {
                if (prediction.PredictionSport == sport)
                {
                    SportPredictions.Add(prediction);
                }
            }
            return SportPredictions;
        }

    }
}
