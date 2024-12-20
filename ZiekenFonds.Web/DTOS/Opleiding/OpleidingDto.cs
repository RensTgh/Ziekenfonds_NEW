﻿namespace ZiekenFonds.Web.DTOS.Opleiding
{
    public class OpleidingDto
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string Beschrijving { get; set; }

        public DateTime Begindatum { get; set; }

        public DateTime Einddatum { get; set; }

        public int AantalPlaatsen { get; set; }
    }
}