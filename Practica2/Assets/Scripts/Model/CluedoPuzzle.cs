﻿namespace UCM.IAV.Puzzles.Model {

    using System;
    using UCM.IAV.Util;
    using System.Collections.Generic;
    
    // contendra una matriz logica del juego en la que cada elemento
    // representara una casilla perteneciente a un tipo de estancia
    public class CluedoPuzzle : IDeepCloneable<CluedoPuzzle>
    {
        private System.Random rnd = new System.Random();

        public int rows;                          // Dimensión de las filas       
        public int columns;                       // Dimensión de las columnas
        public int roomLength;                    // dimension de cada habitacion

        private int[,] matrix;                    // matriz logica de casillas de cada estancia
        private List<int> possibleRooms = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        
        private static readonly int DEFAULT_ROWS = 9;
        private static readonly int DEFAULT_COLUMNS = 9;
        private static readonly int DEFAULT_ROOM = 3;
        
        public CluedoPuzzle() : this(DEFAULT_ROWS, DEFAULT_COLUMNS, DEFAULT_ROOM) { }
        
        public CluedoPuzzle(int rows, int columns, int roomLength) {
            this.Initialize(rows, columns, roomLength);
        }

        // crea una nueva matriz de rows * cols de tipos de estancia aleatorios
        public void Initialize(int rows, int columns, int roomLength)
        {
            if (rows == 0) throw new ArgumentException(string.Format("{0} is not a valid rows value", rows), "rows");
            if (columns == 0) throw new ArgumentException(string.Format("{0} is not a valid columns value", columns), "columns");
            if (roomLength == 0 || rows % roomLength != 0 || columns % roomLength != 0)
                throw new ArgumentException(string.Format("{0} is not a valid room length value", roomLength), "length");

            this.rows = rows;
            this.columns = columns;
            this.roomLength = roomLength;

            matrix = new int[rows, columns];

            for (int r = 0; r < rows; r += roomLength)
            {
                for (int c = 0; c < columns; c += roomLength)
                {
                    int aux = rnd.Next(0, possibleRooms.Count);
                    for (int i = r; i < r + roomLength; i++)
                    {
                        for (int j = c; j < c + roomLength; j++)
                        {
                            matrix[i, j] = possibleRooms[aux];
                        }
                    }
                    possibleRooms.RemoveAt(aux);
                }
            }

            // para cada ficha del gm le elegimos una posicion logica aleatoria
            for(int i = 0; i < GameManager.instance.fichas.Count; i++)
            {
                Position pos = new Position(rnd.Next(0, rows), rnd.Next(0, columns));
                GameManager.instance.fichas[i].Initialize(GameManager.instance.names[i], pos);
            }
        }
        
        // devuelve el tipo de estancia de la casilla en esa posicion
        public int GetType(int r, int c) {
            if (r >= rows) throw new ArgumentException(string.Format("{0} is not a valid row for this matrix", r), "row");
            if (c >= columns) throw new ArgumentException(string.Format("{0} is not a valid column for this matrix", c), "column");
            
            return matrix[r, c];
        }

        // establece el tipo de estancia de la casilla en esa posicion
        public void SetType(int r, int c, int type)
        {
            if (r >= rows) throw new ArgumentException(string.Format("{0} is not a valid row for this matrix", r), "row");
            if (c >= columns) throw new ArgumentException(string.Format("{0} is not a valid column for this matrix", c), "column");

            matrix[r, c] = type;
        }

        // copia un juego recibido
        public CluedoPuzzle(CluedoPuzzle puzzle)
        {
            this.rows = puzzle.rows;
            this.columns = puzzle.columns;

            matrix = new int[rows, columns];
            for (var r = 0u; r < rows; r++)
                for (var c = 0u; c < columns; c++)
                    matrix[r, c] = puzzle.matrix[r, c];
        }

        // Devuelve este objeto clonado a nivel profundo
        public CluedoPuzzle DeepClone()
        {
            // Uso el constructor de copia para generar un clon
            return new CluedoPuzzle(this);
        }

        // Devuelve este objeto de tipo TankPuzzle clonado a nivel profundo 
        object IDeepCloneable.DeepClone()
        {
            return this.DeepClone();
        }
    }
}

