using System;
using System.Collections.Generic;
using System.Linq;

namespace GameMemoriLogic
{
    public class MemoryGame
    {
        public List<Card> Cards { get; private set; }
        public List<Player> Players { get; private set; }
        public GameMode CurrentGameMode { get; private set; }
        public BoardSize CurrentBoardSize { get; private set; }
        public int CurrentPlayerIndex { get; private set; }
        public Card FirstSelectedCard { get; private set; }
        public Card SecondSelectedCard { get; private set; }
        public bool IsWaitingForMatch { get; private set; }
        public DateTime GameStartTime { get; private set; }
        public bool IsGameFinished { get; private set; }
        public Player Winner { get; private set; }

        public MemoryGame(GameMode mode, BoardSize size)
        {
            CurrentGameMode = mode;
            CurrentBoardSize = size;
            InitializeGame();
        } 

        private void InitializeGame()
        {
            int totalCards = (int)CurrentBoardSize;
            int pairs = totalCards / 2;

            Cards = new List<Card>();
            for (int i = 0; i < pairs; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Cards.Add(new Card(Cards.Count, i));
                }
            }

            Random rng = new Random();
            Cards = Cards.OrderBy(x => rng.Next()).ToList();

            Players = new List<Player>();
            switch (CurrentGameMode)
            {
                case GameMode.Solo:
                    Players.Add(new Player("Игрок"));
                    CurrentPlayerIndex = 0;
                    Players[0].IsActive = true;
                    break;
                case GameMode.OneVsOne:
                    Players.Add(new Player("Игрок 1"));
                    Players.Add(new Player("Игрок 2"));
                    CurrentPlayerIndex = 0;
                    Players[0].IsActive = true;
                    break;
                case GameMode.FourPlayers:
                    for (int i = 1; i <= 4; i++)
                        Players.Add(new Player($"Игрок {i}"));
                    CurrentPlayerIndex = 0;
                    Players[0].IsActive = true;
                    break;
            }

            FirstSelectedCard = null;
            SecondSelectedCard = null;
            IsWaitingForMatch = false;
            GameStartTime = DateTime.Now;
            IsGameFinished = false;
            Winner = null;
        }

        public void SelectCard(int cardIndex)
        {
            if (IsGameFinished) return;
            if (Cards[cardIndex].IsMatched) return;
            if (Cards[cardIndex].IsFlipped) return;
            if (IsWaitingForMatch) return;

            if (CurrentGameMode != GameMode.Solo)
            {
                if (Players[CurrentPlayerIndex].TimeLeft <= 0)
                {
                    SwitchToNextPlayer();
                    return;
                }
            }

            if (FirstSelectedCard == null)
            {
                FirstSelectedCard = Cards[cardIndex];
                FirstSelectedCard.IsFlipped = true;
            }
            else if (SecondSelectedCard == null)
            {
                SecondSelectedCard = Cards[cardIndex];
                SecondSelectedCard.IsFlipped = true;
                IsWaitingForMatch = true;

                if (FirstSelectedCard.PairId == SecondSelectedCard.PairId)
                {
                    FirstSelectedCard.IsMatched = true;
                    SecondSelectedCard.IsMatched = true;
                    Players[CurrentPlayerIndex].Score += 10;

                    ResetSelection();

                    if (CheckGameFinished())
                    {
                        EndGame();
                    }
                }
            }
        }

        public void ResetAfterMismatch()
        {
            if (FirstSelectedCard != null && SecondSelectedCard != null)
            {
                FirstSelectedCard.IsFlipped = false;
                SecondSelectedCard.IsFlipped = false;
            }
            ResetSelection();

            if (CurrentGameMode != GameMode.Solo)
            {
                SwitchToNextPlayer();
            }
        }

        private void ResetSelection()
        {
            FirstSelectedCard = null;
            SecondSelectedCard = null;
            IsWaitingForMatch = false;
        }

        private void SwitchToNextPlayer()
        {
            Players[CurrentPlayerIndex].IsActive = false;
            Players[CurrentPlayerIndex].TimeLeft = 30;

            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;

            while (Players[CurrentPlayerIndex].TimeLeft <= 0 && !IsGameFinished)
            {
                CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
            }

            Players[CurrentPlayerIndex].IsActive = true;
        }

        public bool CheckGameFinished()
        {
            return Cards.All(c => c.IsMatched);
        }

        private void EndGame()
        {
            IsGameFinished = true;

            if (CurrentGameMode == GameMode.Solo)
            {
                Winner = Players[0];
            }
            else
            {
                Winner = Players.OrderByDescending(p => p.Score).First();
            }
        }

        public TimeSpan GetElapsedTime()
        {
            if (CurrentGameMode == GameMode.Solo)
                return DateTime.Now - GameStartTime;
            return TimeSpan.Zero;
        }

        public void UpdateTimer()
        {
            if (CurrentGameMode != GameMode.Solo && !IsGameFinished && !IsWaitingForMatch)
            {
                if (Players[CurrentPlayerIndex].TimeLeft > 0)
                {
                    Players[CurrentPlayerIndex].TimeLeft--;
                }
            }
        }
    }
}