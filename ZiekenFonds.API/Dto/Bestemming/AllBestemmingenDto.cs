﻿namespace ZiekenFonds.API.Dto.Bestemming
{
    public class AllBestemmingenDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int MinLeeftijd { get; set; }
        public int MaxLeeftijd { get; set; }
        public List<BestemmingWithFoto> Fotos { get; set; }
        public List<BestemmingWithGroepsreis> Groepsreizen { get; set; }
        public List<BestemmingWithReviews> Reviews { get; set; }
    }
}