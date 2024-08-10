
using SigmaApplication.Entities;

namespace SigmaApplication.Models
{
    public static class CandidateModelMappingConfiguration
    {
        public static IEnumerable<CandidateModel> ToModels(this IEnumerable<Candidate> entities)
        {
            return entities.Select(x => x.ToModel());
        }
        public static CandidateModel ToModel(this Candidate entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CandidateModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Description=entity.Description, 
                Email = entity.Email,
                GitHubURL = entity.GitHubURL,
                LinkedInURL = entity.LinkedInURL,
                PhoneNumber = entity.PhoneNumber,
                TimeIntervalFrom = entity.TimeIntervalFrom,
                TimeIntervalTo =entity.TimeIntervalTo,
                               
            };
        }

        public static Candidate ToEntity(this CandidateModel model)
        {

            return new Candidate
            {
                Id = model.Id,
               PhoneNumber= model.PhoneNumber,
               FirstName = model.FirstName,
               LastName = model.LastName,
               Description=model.Description,
               Email = model.Email, 
               LinkedInURL= model.LinkedInURL,
               GitHubURL = model.GitHubURL ,
               TimeIntervalTo= model.TimeIntervalTo,
               TimeIntervalFrom= model.TimeIntervalFrom,
                              
            };
        }
    }
}
