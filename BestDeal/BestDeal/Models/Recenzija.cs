﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BestDeal.Models
{

    public class Recenzija
    {
        [Required]
        int idRecenzije;
        string tekstRecenzije;
        //double ocjenaArtikla;
        //TODO: specificne ocjene sada iskljucivo ovise o tipu artikla, potrebno je negdje definirati sta su one za koji tip
        //List<Tuple<int, double>> specificneOcjene;
        double batteryLifeRating;
        double designRating;
        double performanceRating;
        double overallRating;

        
        public List<double> specificneOcjene;
        [Required]
        public double BatteryLifeRating { get => batteryLifeRating; set => batteryLifeRating = value; }
        [Required]
        public double DesignRating { get => designRating; set => designRating = value; }
        [Required]
        public double PerformanceRating { get => performanceRating; set => performanceRating = value; }
        [Required]
        public double OverallRating { get => overallRating; set => overallRating = value; }
        [Key]
        public int IdRecenzije { get => idRecenzije; set => idRecenzije = value; }

        // public Recenzija(string tekstRecenzije, double ocjenaArtikla, List<Tuple<int, double>> specificneOcjene)
        public Recenzija(string tekstRecenzije, List<double> specificneOcjene)
        {
            this.tekstRecenzije = tekstRecenzije;
            //this.ocjenaArtikla = ocjenaArtikla;
            //this.specificneOcjene = specificneOcjene;
            this.specificneOcjene = specificneOcjene;
            BatteryLifeRating = specificneOcjene[0];
            DesignRating = specificneOcjene[1];
            PerformanceRating = specificneOcjene[2];
            OverallRating = dajProsjekPojedinacnihRecenzija();
        }

        public Recenzija()
        {
        }

        //Nemamo property jer ne zelimo dozvoliti promjene
        double dajProsjekPojedinacnihRecenzija()
        {
            double suma = 0.0;
            /* for (int i = 0; i < specificneOcjene.Count; i++)
                 suma += specificneOcjene[i].Item2;

             ocjene.OverallRating = suma / specificneOcjene.Count;

             return suma / specificneOcjene.Count;*/

            foreach(double d in specificneOcjene)
                suma += d;

            return suma/specificneOcjene.Count;
        }
        bool daLiJePozitivnaRecenzija()
        {
            return (OverallRating >= 8 && dajProsjekPojedinacnihRecenzija()>=8);
        }

        double getOverallRating()
        {
            return OverallRating;
        }
    }
}
