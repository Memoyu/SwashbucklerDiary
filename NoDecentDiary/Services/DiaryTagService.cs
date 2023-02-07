﻿using NoDecentDiary.IServices;
using NoDecentDiary.Models;

namespace NoDecentDiary.Services
{
    public class DiaryTagService : BaseService<DiaryTagModel>, IDiaryTagService
    {
        public async Task<bool> AddTagsAsync(int diaryId, List<TagModel> tagModels)
        {
            await Init();

            var diaryTags = tagModels
                .Select(it => new DiaryTagModel()
                {
                    DiaryId = diaryId,
                    TagId = it.Id
                })
                .ToList();

            return await AddAsync(diaryTags);
        }
    }
}
