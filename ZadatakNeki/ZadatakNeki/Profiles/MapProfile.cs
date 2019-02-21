using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ZadatakNeki.DTO;
using ZadatakNeki.Models;

namespace ZadatakNeki.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Osoba, OsobaDTO>();
            CreateMap<OsobaDTO, Osoba>();

            CreateMap<Kancelarija, KancelarijaDTO>();
            CreateMap<KancelarijaDTO, Kancelarija>();

            CreateMap<Uredjaj, UredjajDTO>();
            CreateMap<UredjajDTO, Uredjaj>();

            CreateMap<OsobaUredjaj, OsobaUredjajDTO>()
                .ForMember(dest => dest.PocetakKoriscenja, source => source.MapFrom(src => src.PocetakKoriscenja))
                .ForMember(dest => dest.KrajKoriscenja, source => source.MapFrom(src => src.KrajKoriscenja))
                .ForMember(dest => dest.Osoba, source => source.MapFrom(src => src.Osoba))
                .ForMember(dest => dest.Uredjaj, source => source.MapFrom(src => src.Uredjaj));
            CreateMap<OsobaUredjajDTO, OsobaUredjaj>()
                .ForMember(dest => dest.PocetakKoriscenja, source => source.MapFrom(src => src.PocetakKoriscenja))
                .ForMember(dest => dest.KrajKoriscenja, source => source.MapFrom(src => src.KrajKoriscenja))
                .ForMember(dest => dest.Osoba, source => source.MapFrom(src => src.Osoba))
                .ForMember(dest => dest.Uredjaj, source => source.MapFrom(src => src.Uredjaj));
        }
    }
}
