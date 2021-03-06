﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Suspensoes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo de suspensão é obrigatório")]
        [DisplayName("Tipo de Suspensão")]
        [MaxLength(30, ErrorMessage = "Tipo de suspensção deve ter no máximo 40 caracteres")]
        public string Nome { get; set; }

        [EnumDataType(typeof(OpcaoStatusSuspensoes))]
        public OpcaoStatusSuspensoes Ativo { get; set; }
        public enum OpcaoStatusSuspensoes
        {
            Sim,
            Nao
        }
    }
}