using System;
using System.Collections.Generic;
using System.Text;

namespace intento12
{
    class Camion
    {
        protected int _idcamion;
        protected double _volumenmax;
        protected int _pesomax;
        protected bool _cargado;
        protected Paquete[] paquetes_camion;
        private int id_momentaneo;
        private double volumen_momentaneo;
        private int peso_momentaneo;

        public Camion(string idcamion, string volumenmax, string pesomax)
        {
            this._idcamion = Convert.ToInt32(idcamion);
            this._volumenmax = Convert.ToDouble(volumenmax);
            this._pesomax = Convert.ToInt32(pesomax);
            this._cargado = false;
        }

        public Camion(int id_momentaneo, double volumen_momentaneo, int peso_momentaneo)
        {
            this.id_momentaneo = id_momentaneo;
            this.volumen_momentaneo = volumen_momentaneo;
            this.peso_momentaneo = peso_momentaneo;
        }

        // get de las variables

        public int GetIdcamion()
        {
            return _idcamion;
        }

        public double GetVolumencamion()
        {
            return _volumenmax;
        }
        public int GetPesocamion()
        {
            return _pesomax;
        }
        public void Paquetescamion(Paquete[] Ncantidad)
        {
            paquetes_camion = Ncantidad;
        }
        public void Setvolumencamion(double Volumencamioncargado)
        {
            _volumenmax = Volumencamioncargado;
        }
        public void Setpesocamion(int Pesocamioncargado)
        {
            _pesomax = Pesocamioncargado;
        }
        public Paquete[] GetPaquetes()
        {
            return paquetes_camion;
        }
    }
}
