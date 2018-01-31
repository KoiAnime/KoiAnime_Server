using System;

namespace KoiAnime_REST_Server.Libs
{
    [Serializable]
    public class Title
    {
        public string WindowCategory { get; set; }
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public int TitleCategory { get; set; }
        public int TitleNumberChapters { get; set; }
        public DateTime TitleStartDateTime { get; set; }
        public string TitleCoverImg { get; set; }
        public int TitleState { get; set; }
        public long TitleViews { get; set; }

        public Title(koianimeDataSet.titleRow row, string windowCategory)
        {
            WindowCategory = windowCategory;
            TitleId = row.id;
            TitleName = row.title_name;
            TitleCategory = row.title_category;
            TitleDescription = row.title_description;
            TitleNumberChapters = row.title_number_chapters;
            TitleStartDateTime = row.title_start_time;
            TitleCoverImg = row.title_cover_img;
            TitleState = row.title_state;
            TitleViews = row.title_views;
        }

        public string GetWindowCategory()
        {
            return WindowCategory;
        }

        public int GetTitleId()
        {
            return TitleId;
        }

        public string GetTitleName()
        {
            return TitleName;
        }

        public string GetTitleDescription()
        {
            return TitleDescription;
        }

        public int GetTitleCategory()
        {
            return TitleCategory;
        }

        public int GetTitleChapterNumbers()
        {
            return TitleNumberChapters;
        }

        public DateTime GetTitleStartDateTime()
        {
            return TitleStartDateTime;
        }

        public string GetTitleCoverImg()
        {
            return TitleCoverImg;
        }

        public int GetTitleState()
        {
            return TitleState;
        }

        public long GetTitleViews()
        {
            return TitleViews;
        }
    }
}
