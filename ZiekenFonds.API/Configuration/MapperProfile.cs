using AutoMapper;
using ZiekenFonds.API.Dto.Opleiding;
using ZiekenFonds.API.Dto.Bestemming;
using ZiekenFonds.API.Dto.Monitor;
using Monitor = ZiekenFonds.API.Models.Monitor;
using ZiekenFonds.API.Dto.Activiteit;
using ZiekenFonds.API.Dto.Groepsreis;
using ZiekenFonds.API.Dto.Onkosten;
using ZiekenFonds.API.Dto.Kind;
using ZiekenFonds.API.Models;
using ZiekenFonds.API.Dto.Gebruiker;

namespace ZiekenFonds.API.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Opleiding Mappings
            CreateMap<Opleiding, OpleidingWithPersonenDto>()
                .ForMember(dest => dest.OpleidingenPersonen, opt => opt.MapFrom(src => src.OpleidingenPersonen))
                .ForMember(dest => dest.VereisteOpleidingen, opt => opt.MapFrom(src => src.VereisteOpleidingen));

            CreateMap<OpleidingPersoon, OpleidingPersoonDto>()
                .ForMember(dest => dest.Voornaam, opt => opt.MapFrom(src => $"{src.Persoon.Voornaam} {src.Persoon.Naam}"))
                .ForMember(dest => dest.OpleidingNaam, opt => opt.MapFrom(src => src.Opleiding.Naam));

            CreateMap<CreateOpleidingDto, Opleiding>()
                .ForMember(dest => dest.VereisteOpleidingen, opt => opt.MapFrom(src => src.VereisteOpleidingIds));

            CreateMap<VoorOpleidingDto, Opleiding>()
                .ReverseMap();

            CreateMap<Opleiding, CreateOpleidingDto>()
                .ReverseMap();

            CreateMap<UpdateOpleidingDto, Opleiding>()
                .ForMember(dest => dest.OpleidingenPersonen, opt => opt.MapFrom(src => src.OpleidingenPersonen));

            CreateMap<OpleidingPersoon, UpdateOpleidingPersoonDto>()
                .ReverseMap();

            CreateMap<OpleidingResponseDto, Opleiding>()
                .ReverseMap();

            //Bestemming controller
            CreateMap<Bestemming, AllBestemmingenDto>();
            CreateMap<Review, BestemmingWithReviews>();
            CreateMap<Foto, BestemmingWithFoto>();
            CreateMap<Groepsreis, BestemmingWithGroepsreis>();

            //Hier de mappings met CreateMap<>()

            //Monitor mappings
            CreateMap<Monitor, GetMonitorDto>()
                .ForMember(dest => dest.Naam, x => x.MapFrom(src => src.Persoon.Naam))
                .ForMember(dest => dest.Leeftijd, opt => opt.MapFrom(src => DateTime.Now.Year - src.Persoon!.Geboortedatum.Year))
                .ForMember(dest => dest.Voornaam, x => x.MapFrom(src => src.Persoon.Voornaam))
                .ForMember(dest => dest.Email, x => x.MapFrom(src => src.Persoon.Email))
                .ForMember(dest => dest.Telefoonnummer, x => x.MapFrom(src => src.Persoon.TelefoonNummer));

            CreateMap<Monitor, GetMonitorDetailsDto>()
                .ForMember(dest => dest.Naam, opt => opt.MapFrom(src => $"{src.Persoon.Naam} {src.Persoon.Voornaam}"))
                .ForMember(dest => dest.Bestemmingen, opt => opt.MapFrom(src => new List<string> { src.Groepsreis.Bestemming.Naam }))
                .ForMember(dest => dest.Opleidingen, opt => opt.MapFrom(src => src.Persoon.OpleidingenPersonen.Select(o => o.Opleiding.Naam).ToList()));

            CreateMap<CreateMonitorDto, Monitor>();
            CreateMap<UpdateMonitorDto, Monitor>();

            // Groepsreis mappings
            CreateMap<Groepsreis, GroepsreisOphalenDto>()
                .ForMember(dest => dest.Bestemming, opt => opt.MapFrom(src => src.Bestemming.Naam));

            CreateMap<Deelnemer, GroepsreisDeelnemerOphalenDto>()
                .ForMember(dest => dest.DeelnemerNaam, opt => opt.MapFrom(src => $"{src.Kind.Voornaam} {src.Kind.Naam}"))
                .ForMember(dest => dest.Omschrijving, opt => opt.MapFrom(src => src.Opmerking))
                .ForMember(dest => dest.NaamVoogd, opt => opt.MapFrom(src => $"{src.Kind.Persoon.Voornaam} {src.Kind.Persoon.Naam}"))
                .ForMember(dest => dest.Telefoonnummer, opt => opt.MapFrom(src => src.Kind.Persoon.TelefoonNummer))
                .ForMember(dest => dest.Medicatie, opt => opt.MapFrom(src => src.Kind.Medicatie))
                .ForMember(dest => dest.Allergieën, opt => opt.MapFrom(src => src.Kind.Allergieën))
                .ForMember(dest => dest.Leeftijd, opt => opt.MapFrom(src => DateTime.Now.Year - src.Kind!.Geboortedatum.Year));

            CreateMap<Programma, GroepsreisProgrammaDto>()
                .ForMember(dest => dest.activiteitTitel, opt => opt.MapFrom(src => src.Activiteit.Naam))
                .ForMember(dest => dest.activiteitOmschrijving, opt => opt.MapFrom(src => src.Activiteit.Beschrijving));

            CreateMap<GroepsreisMakenDto, Groepsreis>()
                .ReverseMap();

            CreateMap<UpdateGroepsreisDto, Groepsreis>();

            CreateMap<Activiteit, ActiviteitOphalenDto>();
            CreateMap<ActiviteitMakenDto, Activiteit>();
            CreateMap<ActiviteitUpdateDto, Activiteit>();

            //Onkosten 
            CreateMap<Onkosten, GetOnkostenDto>();
            CreateMap<CreateOnkostenDto, Onkosten>();
            CreateMap<UpdateOnkostenDto, Onkosten>();

            //Kind
            CreateMap<Kind, GetKind>()
                .ForMember(dest => dest.OuderNaam, opt => opt.MapFrom(src => src.Persoon.Naam))
                .ForMember(dest => dest.OuderVoornaam, opt => opt.MapFrom(src => src.Persoon.Voornaam))
                .ForMember(dest => dest.Allergieën, opt => opt.MapFrom(src => src.Allergieën ?? "Geen"))
                .ForMember(dest => dest.Medicatie, opt => opt.MapFrom(src => src.Medicatie ?? "Geen"));
            CreateMap<CreateKind, Kind>()
                .ForMember(dest => dest.PersoonId, opt => opt.MapFrom(src => src.PersoonId))
                .ForMember(dest => dest.Allergieën, opt => opt.MapFrom(src => src.Allergieën ?? "Geen"))
                .ForMember(dest => dest.Medicatie, opt => opt.MapFrom(src => src.Medicatie ?? "Geen"));
            CreateMap<UpdateKind, Kind>()
                .ForMember(dest => dest.Allergieën, opt => opt.MapFrom(src => src.Allergieën ?? "Geen"))
                .ForMember(dest => dest.Medicatie, opt => opt.MapFrom(src => src.Medicatie ?? "Geen"));

            //Gebruiker 
            CreateMap<RegistratieDto, CustomUser>();
            CreateMap<LoginDto, CustomUser>();
        }
    }
}