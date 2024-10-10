using Podcast.BLL.ViewModels.TopicViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.Services.Contracts;

public interface ITopicService : ICrudService<Topic, TopicViewModel, TopicCreateViewModel, TopicUpdateViewModel>
{

}