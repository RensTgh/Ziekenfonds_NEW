﻿namespace ZiekenFonds.API.Dto.Monitor
{
    public class GetMonitorDto
    {
        public string Id { get; set; }
        public string PersoonId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int Leeftijd { get; set; }
        public string Email { get; set; }
        public string Telefoonnummer { get; set; }

        //TODO: Leeftijd berekening nog gebeuren
    }
}