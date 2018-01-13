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

        public Title(koianimeDataSet.titlesRow row, string windowCategory)
        {
            WindowCategory = windowCategory;
            TitleId = row.id;
            TitleName = row.title;
            TitleCategory = row.category;
            TitleDescription = row.description;
            TitleNumberChapters = row.num_chapters;
            TitleStartDateTime = row.start_date;
            TitleCoverImg = row.cover_img;
            TitleState = row.title_state;
            TitleViews = row.views;
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
