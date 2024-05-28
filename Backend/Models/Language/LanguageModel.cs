using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Language
{
    public class LanguageModel
    {
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public string Name { get; set; }
    }

    #region post
    public class LanguagePost_Request
    {
        [Required]
        public string Name { get; set; } = null!;
    }

    public class LanguagePost_Response
    {
        public int LanguageId { get; set; }
    }
    #endregion


    #region get all

    public class LanguageGetAll_Response
    {
        [Required]
        public List<LanguageModel> Languages { get; set; }
    }
    #endregion


    #region get by id
    //get by id request
    public class LanguageGetById_Request
    {
        [Required]
        public int LanguageId { get; set; }
    }

    public class LanguageGetById_Response
    {
        public int LanguageId { get; set; }
        public string Name { get; set; } = null!;
    }
    #endregion

    #region put

    //pending

    #endregion

    #region Delete
    
    public class LanguageDelete_Response
    {
        public int LanguageId { get; set; }
    }
    #endregion
}
