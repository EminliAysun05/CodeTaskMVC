using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.DAL.DataContext.Entities
{
    public class Episode : Timestample
    {
        public required string Title {  get; set; }
        public required string Description { get; set; }
        public required string CoverUrl {  get; set; }
        public required string MusicUrl {  get; set; }
        public int ViewCount {  get; set; }
        public int DownloadCount {  get; set; }
        public int LikeCount {  get; set; }
        public int DurationInMinute {  get; set; }
        public int SpeakerId {  get; set; }
        public Speaker? Speaker { get; set; }
        public int TopicId {  get; set; }
        public Topic? Topic { get; set; }
    }
}
