using AutoMapper;
using Podcast.BLL.ViewModels.EpisodeViewModels;
using Podcast.BLL.ViewModels.ProfessionViewModels;
using Podcast.BLL.ViewModels.SpeakerProfessionViewModels;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.BLL.ViewModels.TopicViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Speaker, SpeakerViewModel>()
            .ForMember(dest => dest.Professions, 
            opt => opt.MapFrom(src => src.SpeakerProfessions!.Select(sp => sp.Profession)))
            .ReverseMap();

        CreateMap<SpeakerCreateViewModel, Speaker>()
            .ForMember(dest=>dest.SpeakerProfessions, 
            opt=>opt.MapFrom(src=>src.ProfessionIds.Select(x=>new SpeakerProfession { ProfessionId = x}))).ReverseMap();
        CreateMap<Speaker, SpeakerUpdateViewModel>().ReverseMap();


        CreateMap<Profession, ProfessionViewModel>().ReverseMap();

        CreateMap<TopicViewModel, Topic>().ReverseMap();
        CreateMap<TopicCreateViewModel, Topic>().ReverseMap();
        CreateMap<TopicUpdateViewModel, Topic>().ReverseMap();

        CreateMap<EpisodeViewModel, Episode>().ReverseMap();
        CreateMap<EpisodeCreateViewModel, Episode>().ReverseMap();
        CreateMap<EpisodeUpdateViewModel, Episode>().ReverseMap();

        CreateMap<SpeakerProfessionViewModel, SpeakerProfession>().ReverseMap();
        CreateMap<SpeakerProfessionCreateViewModel, SpeakerProfession>().ReverseMap();
        CreateMap<SpeakerProfessionUpdateViewModel, SpeakerProfession>().ReverseMap();
    }
}
