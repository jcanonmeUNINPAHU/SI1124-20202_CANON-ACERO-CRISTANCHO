using System;
using System.Collections.Generic;
using System.Text;

namespace intento12
{
    class Paquete
    {
        protected int _idpaquete;
        protected float _volumenpaquete;
        protected int _pesopaquete;
        protected bool _salio;
        private int id_paquete_momentaneo;
        private double volumen_paquete_momentaneo;
        private int peso_paquete_momentaneo;

        public Paquete(string id, string volumen, string peso)
        {
            this._idpaquete = Convert.ToInt32(id);
            this._volumenpaquete = (float)Convert.ToDouble(volumen);
            this._pesopaquete = Convert.ToInt32(peso);
            this._salio = false;
        }

        public Paquete(int id_paquete_momentaneo, double volumen_paquete_momentaneo, int peso_paquete_momentaneo)
        {
            this.id_paquete_momentaneo = id_paquete_momentaneo;
            this.volumen_paquete_momentaneo = volumen_paquete_momentaneo;
            this.peso_paquete_momentaneo = peso_paquete_momentaneo;
        }

        //get de las variables
        public int getId()
        {
            return _idpaquete;
        }
        public double GetVolumen()
        {
            return _volumenpaquete;
        }
        public int GetPeso()
        {
            return _pesopaquete;
        }
        public void Estacargado(Boolean salio)
        {
            this._salio = salio;
        }
        public Boolean Setcargado()
        {
            return _salio;
        }

        public double sumadelosnocargados()
        {
            _volumenpaquete = _volumenpaquete + _volumenpaquete;
            return _volumenpaquete;
        }
    }
}
