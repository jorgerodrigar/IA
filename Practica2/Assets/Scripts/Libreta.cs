﻿namespace UCM.IAV.Puzzles
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Libreta : MonoBehaviour {

        private static readonly int DEFAULT_ROWS = 21;
        private static readonly int DEFAULT_COLUMNS = 3;
        private string[] cardNames = {
            "Biblioteca", "Cocina", "Comedor", "Estudio", "Pasillo", "Recibidor", "Billar", "Baile", "Terraza",
            "A", "B", "C", "M", "P", "R",
            "Candelabro", "Cuerda", "Herramienta", "Pistola", "Puñal", "Tuberia"
        };

        public enum TipoLibreta { N, X, O };
        public TipoLibreta[,] libreta;
        public TipoEstancia estanciaActual;
        public int sospechosoActual;

        public void Initialize()
        {
            libreta = new TipoLibreta[DEFAULT_ROWS, DEFAULT_COLUMNS];
            for(int i = 0; i < DEFAULT_ROWS; i++)
            {
                for(int j = 0; j < DEFAULT_COLUMNS; j++)
                {
                    libreta[i, j] = TipoLibreta.N;
                }
            }
        }

        public void receiveCard(string card, int turno)
        {
            for (int i = 0; i < DEFAULT_COLUMNS; i++)
            {
                if(i == turno)
                    libreta[getRowFromCard(card), i] = TipoLibreta.O;
                else
                    libreta[getRowFromCard(card), i] = TipoLibreta.X;
            }
        }

        private int getRowFromCard(string card)
        {
            int i = 0;
            while (i < DEFAULT_ROWS && cardNames[i] != card) i++;
            return i;
        }
    }
}
