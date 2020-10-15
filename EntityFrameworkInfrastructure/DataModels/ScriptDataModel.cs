using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkInfrastructure.DataModels
{
    [Table("Scripts")]
    public class ScriptDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string Section { get; set; }

        [Required]
        public string Content { get; set; }
    }
}

/*
CREATE TABLE [dbo].[Scripts]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [section] NVARCHAR(50) NOT NULL, 
    [content] NVARCHAR(100) NOT NULL
)
 */
