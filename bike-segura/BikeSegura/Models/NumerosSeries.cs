﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class NumerosSeries
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Número de série é obrigatório")]
        [DisplayName("Número de Série")]
        [MaxLength(50, ErrorMessage = "Número de série deve ter no máximo 50 caracteres")]
        public string Numero { get; set; }

        [DisplayName("Bicicleta")]
        [Required(ErrorMessage = "Bicicleta é obrigatório")]
        public int BicicletasId { get; set; }

        [EnumDataType(typeof(OpcaoNumerosSeries))]
        public OpcaoNumerosSeries Tipo { get; set; }
        public enum OpcaoNumerosSeries
        {
            Quadro,
            [Display(Name = "Suspensão Dianteira")]
            SuspensaoDianteira,
            [Display(Name = "Suspensão Traseira")]
            SuspensaoTraseira,
            Garfo,
            [Display(Name = "OUTRO")]
            Outro
        }

        [EnumDataType(typeof(OpcaoStatusNumerosSeries))]
        public OpcaoStatusNumerosSeries Ativo { get; set; }
        public enum OpcaoStatusNumerosSeries
        {
            Sim,
            Nao
        }

        public virtual Bicicletas Bicicletas { get; set; }
    }
}