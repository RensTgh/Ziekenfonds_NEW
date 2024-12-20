﻿using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.Web.DTOS.Monitor
{
    public class CreateMonitorDTO
    {
        [Required(ErrorMessage = "UserId is verplicht")]
        public string PersoonId { get; set; }

        [Required(ErrorMessage = "GroepreisId is verplicht")]
        public int GroepsreisId { get; set; }

        public bool IsHoofdMonitor { get; set; }
    }
}