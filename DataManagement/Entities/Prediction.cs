﻿namespace DataManagement.Entities
{
    public class Prediction
    {
        private int Id;
        public string Analyse { get; private set; }
        public string FinalPrediction { get; private set; }
        public int TipsterId { get; private set; }
        public int MatchId { get; private set; }
        public Prediction(string analyse, string finalPrediction, int tipsterId, int matchId)
        {
            Analyse = analyse;
            FinalPrediction = finalPrediction;
            TipsterId = tipsterId;
            MatchId = matchId;
        }
        public int GetId()
        {
            return Id;
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
