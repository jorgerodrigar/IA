﻿namespace UCM.IAV.Puzzles {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Model;

    // clase ficha que tendran todos los personajes (representacion grafica de sospechosos y jugadores)
    public class Ficha : MonoBehaviour {
        private Character character_;
        private GameManager gm;

        public string name_;      // nombre que escribira el texto
        public Position position; // posicion logica

        public void setCharacter(Character character) {
            character_ = character;
        }

        public Ficha() : base() { gm = GameManager.instance; }

        public void Initialize(string name, Position position)
        {
            this.name_ = name;
            this.position = position;
            this.gameObject.GetComponent<TextMesh>().text = this.name_;
        }

        // al ser pulsado, se lo comunica a su personaje
        public bool OnMouseUpAsButton()
        {
            if (gm.isPlayerTurn())
                character_.onClicked();
            return false;
        }

        // set/get de la posicion fisica
        public void setPosition(Vector3 pos) { this.transform.position = pos; }
        public void setLogicPosition(Position pos) { this.position = pos; }
        public Vector3 getPosition() { return this.transform.position; }
        public Position getLogicPosition() { return this.position; }
    }
}
