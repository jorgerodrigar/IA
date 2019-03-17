﻿namespace UCM.IAV.Puzzles
{
    using System;
    using UnityEngine;
    using Model;

    // casilla que puede ser del tipo de cualquier estancia
    // cada tipo con un valor y color distintos (representacion grafica)
    public class Casilla : MonoBehaviour
    {
        private Tablero tablero; // tablero de casillas

        // colores posibles y sus respectivos valores (dependen del tipo)
        private Color[] colors = {
            new Color(0.3f, 0.85f, 0.8f), new Color(0.5f, 0.5f, 0.5f), new Color(0.85f, 0.85f, 0),
            new Color(0.55f, 0, 0.81f), new Color(1, 0.71f, 0.76f), new Color(1, 0.55f, 0),
           new Color(0, 0.5f, 0), new Color(0.5f, 0, 0), new Color(0.54f, 0.27f, 0.1f)
        };

        // tipo y tipo inicial
        private TipoEstancia type;
        private TipoEstancia initialType;

        // actualiza el color dependiendo del tipo de casilla que sea actualmente
        private void UpdateColor() { this.GetComponent<Renderer>().material.color = colors[(uint)this.type]; }
        
        public Position position; // posicion logica dentro de la matriz logica de puzzle
        
        public void Initialize(Tablero tablero, int type)
        {
            this.tablero = tablero;
            this.type = (TipoEstancia)type;
            this.initialType = this.type;

            UpdateColor();
        }

        // al ser pulsado
        public bool OnMouseUpAsButton()
        {
            if (tablero == null) throw new InvalidOperationException("This object has not been initialized");

            return false;
        }
        
        public TipoEstancia getType() { return this.type; }

        // Cadena de texto representativa
        public override string ToString()
        {
            return "Casilla de tipo " + this.type.ToString() + " en " + position;
        }
    }
}