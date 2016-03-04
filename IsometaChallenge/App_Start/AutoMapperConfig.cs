using AutoMapper;
using IsometaChallenge.Models;

namespace IsometaChallenge
{
    public static class AutoMapper
    {
        public static MapperConfiguration Config { get; set; }
        public static IMapper Mapper { get; set; }
        public static void RegisterMappings()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistViewModel>().ForMember(n=>n.GenreName,m=>m.MapFrom(src=>src.Genre.Name));
                cfg.CreateMap<ArtistViewModel, Artist>();
                cfg.CreateMap<Genre, GenreViewModel>().ForMember(n => n.CountArtists, m => m.MapFrom(src => src.Artists.Count));
                cfg.CreateMap<GenreViewModel, Genre>();
            });

            Mapper = Config.CreateMapper();
        }
    }
}